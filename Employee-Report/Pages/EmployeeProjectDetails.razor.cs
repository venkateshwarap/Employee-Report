using Employee_Report.API.Entities;
using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Employee_Report.Services;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class EmployeeProjectDetails
    {
        [Inject]
        public EmployeeProjectService Service { get; set; }
        public IEnumerable<EmployeeProjectEntity> employee { get; set; }

        public EmployeeProject employeeProject = new();
        private bool IsHidden { get; set; } = false;

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
        protected override async Task OnInitializedAsync()
        {
            employee = (await Service.GetEmployeeProjectDetails()).ToList();
        }

        private async void addProject()
        {
            if (employeeProject != null)
            {
                var response = await Service.AddEmployeeProject(employeeProject);  
                
                if(response.IsSuccessStatusCode)
                {
                    navManager.NavigateTo("/employeeProjectDetails", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
    }
}
