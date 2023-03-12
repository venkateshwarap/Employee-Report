using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages
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
            poc = (await employeePocService.GetPOCDetails()).ToList();
        }
        private async void AddPOC()
        {
            if (pocModel != null)
            {
                var response = await employeePocService.AddPOC(pocModel);
                if (response.IsSuccessStatusCode)
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
