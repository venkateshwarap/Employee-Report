using Employee.DataModel.Models;
using Employee_Report.Repository.Services;
using Employee_Report.Utilities;

namespace Employee_Report.Pages
{
    public partial class EmployeeSkillsPage
    {
        private readonly Repository.Services.EmployeeSkillService employeeSkillService = new Repository.Services.EmployeeSkillService();
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
            employeeSkills_SkillsDetails = (await employeeSkillService.GetEmployeeSkills_Skills()).ToList();
            var response = await SkillsService.GetSkills();
            skillDetails = Utility.GetResponseData<List<Skill>>(response.response);
        }
        public async void AddEmployeeSkill()

        {
            if (employeeSkills != null)
            {
                var response = await employeeSkillService.AddEmployeeSkills_Skils(employeeSkills);
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
