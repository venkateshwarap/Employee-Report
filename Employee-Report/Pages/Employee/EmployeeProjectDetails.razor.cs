using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components.Web;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeProjectDetails
    {
        Repository.Services.EmployeeProjectService employeeProjectService = new Repository.Services.EmployeeProjectService();
        public IEnumerable<EmployeeProjectEntity> employee { get; set; }
        public EmployeeProject employeeProject = new();
        IEnumerable<Project> projectDetails { get; set; }
        Repository.Services.GetRoleService roleService = new();
        List<Role> roleDetails = new List<Role>();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {   var emp_resp = await employeeProjectService.GetEmployeeProjectDetails();
            employee = Utility.GetResponseData<IEnumerable<EmployeeProjectEntity>>(emp_resp.response);
            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = Utility.GetResponseData<List<Role>>(roleResponse.response);
            var project_response = await employeeProjectService.GetProjectDetails();
            projectDetails = Utility.GetResponseData<IEnumerable<Project>>(project_response.response);
        }
        public async void addProject()
        {
            if (employeeProject != null)
            {
                var response = await employeeProjectService.AddEmployeeProject(employeeProject);
                if (response.status)
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
