using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using System.Collections.Generic;

namespace Employee_Report.Pages.Admin
{
    public partial class ProjectDetails
    {
        Repository.Services.EmployeeProjectService employeeProjectService = new Repository.Services.EmployeeProjectService();
        public IEnumerable<Project> projects { get; set; }
        private bool IsHidden { get; set; } = false;

        public Project projectModel = new();

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }

        protected override async Task OnInitializedAsync()
        {
            var res = await employeeProjectService.GetAdminProjectDetails();
            if (res.status) { 
            projects = Utility.GetResponseData<IEnumerable<Project>>(res.response);
            }
        }

        private async void AddProject()
        {
            if (projectModel != null)
            {
                var response = await employeeProjectService.CreateAdminProject(projectModel);
                if (response.status)
                {
                    navManager.NavigateTo("/projects", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void CancelProject()
        {
            navManager.NavigateTo("/projects", forceLoad: true);
        }
    }
}
