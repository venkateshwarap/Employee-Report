using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class EACouncilEntryExitPage
    {
        [Inject]
        public Repository.IServices.IEACouncilService benchServices { get; set; }
        public IEnumerable<EacouncilEntryExit> benchdetails { get; set; }
        public EacouncilEntryExit entryExit = new();
        private bool IsHidden { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            var response = await benchServices.GeEACouncilEntryDetails();
            benchdetails = Utility.GetResponseData<List<EacouncilEntryExit>>(response.response);
        }
        private async void SaveEntry()
        {
            if (entryExit != null)
            {
                var response = await benchServices.CreateEACouncilEntryDetails(entryExit);
                if (response.status)
                {
                    navManager.NavigateTo("/eacouncil", forceLoad: true);
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
