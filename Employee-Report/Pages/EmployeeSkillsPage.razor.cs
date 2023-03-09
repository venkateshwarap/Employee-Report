using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages
{
    public partial class EmployeeSkillsPage
    {
        Repository.Services.EmployeeSkillsService EmployeeSkillsService = new();
        public IEnumerable<EmployeeSkills>? employeeSkillDetails { get; set; }
        public EmployeeSkills employeeSkillModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await EmployeeSkillsService.GetEmployeeSkills();
            employeeSkillDetails = Utility.GetResponseData<List<EmployeeSkills>>(response.response);
        }

        public async void addEmployeeSkill()
        {
            if (employeeSkillModel != null)
            {
                //var response = await interviewService.AddInterview(InterviewModel);
                var response = await EmployeeSkillsService.AddEmployeeSkill(employeeSkillModel);
                if (response.status)
                {
                    navManager.NavigateTo("/EmployeeSkills", forceLoad: true);
                    IsHidden = false;
                }

            }
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
