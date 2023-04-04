using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components.Web;
using Employee_Report.Repository.IServices;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeePOC
    {
        [Inject]
        private  IEmployeePocService _employeePocService { get; set; }
        [Inject]
        private  IGetRoleService roleService { get; set; }
        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }
        IEnumerable<Poc> pocDetails { get; set; }
       
        IEnumerable<Role> roleDetails = new List<Role>();

        public EmployeePoc employeePocModel = new();
        private bool IsHidden { get; set; } = false;

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
        protected override async Task OnInitializedAsync()
        {
            var employee_poc_resp = await _employeePocService.GetEmployeePOCDetails();
            if(employee_poc_resp.status) 
            {
                employeepoc = Utility.GetResponseData<IEnumerable<EmployeePOCEntity>>(employee_poc_resp.response);
            }
            var poc_response = await _employeePocService.GetPOCDetails();
            pocDetails = Utility.GetResponseData<IEnumerable<Poc>>(poc_response.response);
            var roleResponse = await roleService.GetRoleDetails();
            if (roleResponse.status)
            {
                roleDetails = Utility.GetResponseData<IEnumerable<Role>>(roleResponse.response);
            }
        }

        private async void AddEmployeePOC()
        {
            if (employeePocModel != null)
            {
                var response = await _employeePocService.AddEmployeePOC(employeePocModel);
                if (response.status)
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
