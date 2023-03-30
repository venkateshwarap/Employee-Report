using Employee.DataModel.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeInterviewsPage
    {
        Repository.Services.InterviewService interviewService = new Repository.Services.InterviewService();
        public IEnumerable<Interview>? interviewsDetails { get; set; }
        public Interview InterviewModel = new();
        private bool IsHidden { get; set; } = false;

        Repository.Services.SkillsService skillsService = new();
        List<Skill> skillDetails = new List<Skill>();

        Repository.Services.GetRoleService roleService = new();
        List<Role> roleDetails = new List<Role>();

        List<string> selectionlist = new List<string> { "Selected", "Rejected" };
        protected override async Task OnInitializedAsync()
        {
            var response = await interviewService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);
            var skillResponse = await skillsService.GetSkills();
            skillDetails = Utility.GetResponseData<List<Skill>>(skillResponse.response);

            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = roleResponse.ToList();
        }

        public async void AddInterview()
        {
            if (InterviewModel != null)
            {
                var response = await interviewService.AddInterview(InterviewModel);
                if (response.status)
                {
                    navManager.NavigateTo("/Interviews", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        public void CancelInterview()
        {
            navManager.NavigateTo("/Interviews", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
