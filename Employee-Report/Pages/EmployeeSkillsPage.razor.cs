using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages
{
    public partial class EmployeeSkillsPage
    {
        private readonly Repository.Services.EmployeeSkillService employeeSkillService = new Repository.Services.EmployeeSkillService();
        public IEnumerable<EmployeeSkills_Skills_Entity> employeeSkills_SkillsDetails { get; set; }
        public EmployeeSkills_Skills_Entity EmployeeSkills_SkillsModel = new EmployeeSkills_Skills_Entity();
        public EmployeeSkills empSkillsModel = new EmployeeSkills();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            employeeSkills_SkillsDetails = (await employeeSkillService.GetEmployeeSkills_Skills()).ToList();
        }
        public async void AddEmployeeSkill()
        {
            if (employeeSkillService != null)
            {
                var response = await employeeSkillService.AddEmployeeSkills_Skils(EmployeeSkills_SkillsModel);
                if (response.IsSuccessStatusCode)
                {
                    IsHidden = false;
                    navManager.NavigateTo("/EmployeeSkills", forceLoad: true);
                }
            }
        }

        public void CancelEmployeeSkill()
        {
            navManager.NavigateTo("/EmployeeSkills", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
