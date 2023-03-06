using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using Employee_Report.Services;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class EmployeePOC
    {
        [Inject]
        public EmployeePocService pocService { get; set; }
        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }

        public EmployeePoc employeePocModel = new();
        private bool IsHidden { get; set; } = false;

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
        protected override async Task OnInitializedAsync()
        {
            employeepoc = (await pocService.GetEmployeePOCDetails()).ToList();
        }

        private async void addEmployeePOC()
        {
            if (employeePocModel != null)
            {
                var response = await pocService.AddPOC(employeePocModel);
                if (response.IsSuccessStatusCode)
                {
                    navManager.NavigateTo("/employeePocDetails", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
    }
}
