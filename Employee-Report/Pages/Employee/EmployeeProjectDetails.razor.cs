using Employee.DataModel.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeProjectDetails
    {
        Repository.Services.EmployeeProjectService employeeProjectService = new Repository.Services.EmployeeProjectService();
        public IEnumerable<EmployeeProjectEntity> employee { get; set; }
        public EmployeeProject employeeProject = new();
        List<Project> projectDetails = new List<Project>();
        Repository.Services.GetRoleService roleService = new();
        List<Role> roleDetails = new List<Role>();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            employee = (await employeeProjectService.GetEmployeeProjectDetails()).ToList();
            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = roleResponse.ToList();
            var response = await employeeProjectService.GetProjectDetails();
            projectDetails = response.ToList();
        }
        public async void addProject()
        {
            if (employeeProject != null)
            {
                var response = await employeeProjectService.AddEmployeeProject(employeeProject);
                if (response.IsSuccessStatusCode)
                {
                    navManager.NavigateTo("/employeeProjectDetails", forceLoad: true);
                    IsHidden = false;
                }

            }
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }

        public void Clicked(MouseEventArgs Args)
        {

            navManager.NavigateTo("/reports/EmpId");
        }
    }
}
