using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages
{
    public partial class EmployeeProjectDetails
    {
        Repository.Services.EmployeeProjectService employeeProjectService = new Repository.Services.EmployeeProjectService();
        public IEnumerable<EmployeeProjectEntity> employee { get; set; }
        public EmployeeProject employeeProject = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            employee = (await employeeProjectService.GetEmployeeProjectDetails()).ToList();
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
    }
}
