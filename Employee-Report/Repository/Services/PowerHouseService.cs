using Employee_Report.Model.Models;
using Employee_Report.Model.ModelView;
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
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_POWER_HOUSE, _httpClient);
            return entry;
        }
        public async Task<Response> CreateEACouncilEntryDetails(PowerHouseRoleView powerHouse_Role)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_POWERHOUSE_ROLE, _httpClient, powerHouse_Role);
            return entry;
        }
        public async Task<Response> GetPowerHouseById(string Id)
        {
            var result = await Utility.HttpClientGetAsync(AppSettings.Config.GET_POWERHOUS_BY_ID, Id, _httpClient);
            return result;
        }
    }
}
