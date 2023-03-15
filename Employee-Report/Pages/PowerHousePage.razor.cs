using Employee.DataModel.Models;


namespace Employee_Report.Pages
{
    public partial class PowerHousePage
    {
        private readonly Repository.Services.PowerHouseService powerHouseService = new Repository.Services.PowerHouseService();
        public IEnumerable<PowerHouse_Role> powerHouse_RolesDeatils { get; set; }
        public PowerHouse_Role PowerHouse_RoleDetails = new PowerHouse_Role();
        public PowerHouse PowerHouseModel = new PowerHouse();
        public PowerHouse_Role PowerHouse_RoleModel = new PowerHouse_Role();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            powerHouse_RolesDeatils = (await powerHouseService.GeEACouncilEntryDetails()).ToList();
            //employeeSkills_SkillsDetails = (await employeeSkillService.GetEmployeeSkills_Skills()).ToList();
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
