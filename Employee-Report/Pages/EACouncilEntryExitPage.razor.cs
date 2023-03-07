using Employee_Report.Model.Models;
using Employee_Report.Repository.Services;
using EmployeeDetails.Api.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class EACouncilEntryExitPage
    {
        [Inject]
        public EACouncilService benchServices { get; set; }
        public IEnumerable<EACouncilEntryExit> benchdetails { get; set; }
        public EACouncilEntryExit entryExit = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await benchServices.GetBenchEntry();
            benchdetails = Utility.GetResponseData<List<EACouncilEntryExit>>(response.response);
        }
        private async void SaveEntry()
        {
            if (entryExit != null)
            {
                var response = await benchServices.CreateBenchEntry(entryExit);
                if (response.status)
                {
                    navManager.NavigateTo("/bench", forceLoad: true);
                    IsHidden = false;
                }

            }
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
