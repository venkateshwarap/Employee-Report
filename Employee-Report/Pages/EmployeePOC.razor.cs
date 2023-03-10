using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Employee_Report.Pages
{
    public partial class EmployeePOC
    {
        Repository.Services.EmployeePocService employeePocService = new Repository.Services.EmployeePocService();
        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }

        public EmployeePoc employeePocModel = new();
        private bool IsHidden { get; set; } = false;

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
        protected override async Task OnInitializedAsync()
        {
            employeepoc = (await employeePocService.GetEmployeePOCDetails()).ToList();
        }

        private async void addEmployeePOC()
        {
            if (employeePocModel != null)
            {
                var response = await employeePocService.AddEmployeePOC(employeePocModel);
                if (response.IsSuccessStatusCode)
                {
                    navManager.NavigateTo("/employeePocDetails", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        public void Clicked(MouseEventArgs Args)
        {

            navManager.NavigateTo("/reports/EmpId");
        }
    }
}
