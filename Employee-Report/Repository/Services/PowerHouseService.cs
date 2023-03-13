using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class PowerHouseService : IPowerHouseService
    {
        private readonly HttpClient _httpClient;
        public PowerHouseService()
        {
            _httpClient =new HttpClient();
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GeEACouncilEntryDetails()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EA_COUNCIL, _httpClient);
            return entry;
        }
        public async Task<Response> CreateEACouncilEntryDetails(PowerHouse powerHouse)
        {
            powerHouse.CreatedOn = DateTime.Now;
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_EA_COUNCIL_ENTRY, _httpClient, powerHouse);
            return entry;
        }
    }
}
