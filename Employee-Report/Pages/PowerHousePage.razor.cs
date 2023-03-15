using Employee.DataModel.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;


namespace Employee_Report.Pages
{
    public partial class PowerHousePage
    {
        [Inject]
        public Repository.IServices.IPowerHouseService benchServices { get; set; }
        public IEnumerable<PowerHouse> powerHouseDetails { get; set; }
        public PowerHouse powerHouseModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await benchServices.GeEACouncilEntryDetails();
            powerHouseDetails = Utility.GetResponseData<List<PowerHouse>>(response.response);
        }
        private async void SavePowerHouseData()
        {
            if (powerHouseModel != null)
            {
                var response = await benchServices.CreateEACouncilEntryDetails(powerHouseModel);
                if (response.status)
                {
                    navManager.NavigateTo("/power-house", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void CancelPowerHouseData()
        {
            navManager.NavigateTo("/power-house", forceLoad: true);
        }
        private void Save()
        {
            IsHidden = !IsHidden;
        }
        private void Cancel()
        {
            IsHidden = !IsHidden;
        }

    }
}
