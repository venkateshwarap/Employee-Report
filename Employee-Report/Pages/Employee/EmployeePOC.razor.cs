using Azure;
using Employee.DataModel.Models;
using Employee_Report.API.Service;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeePOC
    {
        Repository.Services.EmployeePocService employeePocService = new Repository.Services.EmployeePocService();
        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }
        List<Poc> pocDetails = new List<Poc>();
       
        Repository.Services.GetRoleService roleService = new();
        List<Role> roleDetails = new List<Role>();

        public EmployeePoc employeePocModel = new();
        private bool IsHidden { get; set; } = false;

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
        protected override async Task OnInitializedAsync()
        {
            employeepoc = (await employeePocService.GetEmployeePOCDetails()).ToList();
            var response = await employeePocService.GetPOCDetails();
            pocDetails = response.ToList();
            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = roleResponse.ToList();

        }

        private async void AddEmployeePOC()
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

        private void CancelEmployeePOC()
        {
            navManager.NavigateTo("/employeePocDetails", forceLoad: true);
        }

        public void Clicked(MouseEventArgs Args)
        {

            navManager.NavigateTo("/reports/EmpId");
        }
    }
}
