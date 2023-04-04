using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeSkillsPage
    {
        [Inject]
        private IEmployeeSkillService employeeSkillService { get; set; }
        public IEnumerable<EmployeeSkills_Skills_Entity> employeeSkills_SkillsDetails { get; set; }
        public EmployeeSkills_Skills_Entity EmployeeSkills_SkillsModel = new EmployeeSkills_Skills_Entity();
        public EmployeeSkills empSkillsModel = new EmployeeSkills();
        
        Repository.Services.SkillsService SkillsService = new();
        public EmployeeSkills employeeSkills = new();
        private bool IsHidden { get; set; } = false;

        List<Skill> skillDetails = new List<Skill>();
        public Skill skillModel = new();
        protected override async Task OnInitializedAsync()
        {
            var response  = await employeeSkillService.GetEmployeeSkills();
            if (response.status)
            {
                employeeSkills_SkillsDetails = Utility.GetResponseData<IEnumerable<EmployeeSkills_Skills_Entity>>(response.response);
            }
            
            var skills_response = await SkillsService.GetSkills();
            if (skills_response.status)
            {
                skillDetails = Utility.GetResponseData<List<Skill>>(skills_response.response);
            }
        }
        public async void AddEmployeeSkill()

        {
            if (employeeSkills != null)
            {
                var response = await employeeSkillService.CreateEmployeeSkill(employeeSkills);
                if (response.status)
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
