using Employee_Report.Model.Models;
using Employee_Report.Model.ModelView;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages.Employee
{
    public partial class PowerHousePage
    {
        [Inject]
        private IPowerHouseService powerHouseService { get;set; }

        [Inject]
        private IGetRoleService roleService { get; set; }
        public IEnumerable<PowerHouseRoleView> powerHouse_RolesDeatils { get; set; }
        public PowerHouseRoleView PowerHouse_RoleDetails = new PowerHouseRoleView();
        public PowerHouse PowerHouseModel = new PowerHouse();
        public PowerHouseRoleView PowerHouse_RoleModel = new PowerHouseRoleView();
        private bool IsHidden { get; set; } = false;

        
        IEnumerable<Role> roleDetails { get; set; }
       protected override async Task OnInitializedAsync()
        {
            var empId = Utility.GetSessionClaim(Constants.EMPLOYEE_ID);
            var resp = await powerHouseService.GetPowerHouseById(empId);
            powerHouse_RolesDeatils = Utility.GetResponseData<IEnumerable<PowerHouseRoleView>>(resp.response);
               
        }
        public async void AddPowerHouseRole()
        {
            if (powerHouseService != null)
            {
                var response = await powerHouseService.CreateEACouncilEntryDetails(PowerHouse_RoleModel);
                if (response.status)
                {
                    navManager.NavigateTo("/power-house", forceLoad: true);
                    IsHidden = false;
                }
            }
        }

        public void CanacPowerHouseRole()
        {
            navManager.NavigateTo("/power-house", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }

    }
}
