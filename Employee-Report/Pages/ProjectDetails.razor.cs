using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages
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
            projects = (await employeeProjectService.GetProjectDetails()).ToList();
        }

        private async void AddProject()
        {
            if (projectModel != null)
            {
                var response = await employeeProjectService.AddProject(projectModel);
                if (response.IsSuccessStatusCode)
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
