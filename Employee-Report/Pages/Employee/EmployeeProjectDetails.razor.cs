using Employee_Report.Model.Models;
using Employee_Report.Model.ModelView;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components.Web;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeProjectDetails
    {
        Repository.Services.EmployeeProjectService employeeProjectService = new Repository.Services.EmployeeProjectService();
        public IEnumerable<EmployeeProjectView> employee { get; set; }
        public EmployeeProject employeeProject = new();
        IEnumerable<Project> projectDetails { get; set; }
        Repository.Services.GetRoleService roleService = new();
        List<Role> roleDetails = new List<Role>();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var _empId = Utility.GetSessionClaim(Constants.EMPLOYEE_ID);
            var emp_resp = await employeeProjectService.GetEmployeeProjectDetailsById(_empId);
            if (emp_resp.status)
            {
                employee = Utility.GetResponseData<IEnumerable<EmployeeProjectView>>(emp_resp.response);
            }
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
