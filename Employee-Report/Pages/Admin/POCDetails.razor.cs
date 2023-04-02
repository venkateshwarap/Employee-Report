using Employee_Report.Model.Models;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Admin
{
    public partial class POCDetails
    {

        Repository.Services.EmployeePocService employeePocService = new Repository.Services.EmployeePocService();
        public IEnumerable<Poc> poc { get; set; }
        private bool IsHidden { get; set; } = false;

        public Poc pocModel = new();

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }

        protected override async Task OnInitializedAsync()
        {
            var poc_resp = await employeePocService.GetPOCDetails();
            if(poc_resp.status)
            {
                poc = Utility.GetResponseData<IEnumerable<Poc>>(poc_resp.response);
            }
        }
        private async void AddPOC()
        {
            if (pocModel != null)
            {
                var response = await employeePocService.AddPOC(pocModel);
                if (response.status)
                {
                    navManager.NavigateTo("/poc", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void CancelPOC()
        {
            navManager.NavigateTo("/poc", forceLoad: true);
        }
    }
}
