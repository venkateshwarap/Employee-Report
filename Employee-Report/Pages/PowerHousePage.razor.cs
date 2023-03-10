using Employee.DataModel.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;


namespace Employee_Report.Pages
{
    public partial class PowerHousePage
    {
        [Inject]
        public Repository.IServices.IPowerHouseService benchServices { get; set; }
        public IEnumerable<PowerHouse> benchdetails { get; set; }
        public PowerHouse entryExit = new();
        private bool IsHidden { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            var response = await benchServices.GeEACouncilEntryDetails();
            benchdetails = Utility.GetResponseData<List<PowerHouse>>(response.response);
        }
        private async void SaveEntry()
        {
            if (entryExit != null)
            {
                var response = await benchServices.CreateEACouncilEntryDetails(entryExit);
                if (response.status)
                {
                    navManager.NavigateTo("/power-house", forceLoad: true);
                    IsHidden = false;
                }

            }
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
