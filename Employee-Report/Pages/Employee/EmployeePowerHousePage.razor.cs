using Employee.DataModel.Models;


namespace Employee_Report.Pages.Employee
{
    public partial class EmployeePowerHousePage
    {
        private readonly Repository.Services.PowerHouseService powerHouseService = new Repository.Services.PowerHouseService();
        public IEnumerable<PowerHouse_Role> powerHouse_RolesDeatils { get; set; }
        public PowerHouse_Role PowerHouse_RoleDetails = new PowerHouse_Role();
        public PowerHouse PowerHouseModel = new PowerHouse();
        public PowerHouse_Role PowerHouse_RoleModel = new PowerHouse_Role();
        private bool IsHidden { get; set; } = false;

        Repository.Services.GetRoleService roleService = new();
        List<Role> roleDetails = new List<Role>();

        protected override async Task OnInitializedAsync()
        {
            powerHouse_RolesDeatils = (await powerHouseService.GeEACouncilEntryDetails()).ToList();
            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = roleResponse.ToList();
        }
        public async void AddPowerHouseRole()
        {
            if (powerHouseService != null)
            {
                var response = await powerHouseService.CreateEACouncilEntryDetails(PowerHouse_RoleModel);
                if (response.IsSuccessStatusCode)
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
