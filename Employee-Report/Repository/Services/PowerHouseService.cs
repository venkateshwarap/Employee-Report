using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;

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
        public async Task<IEnumerable<PowerHouse_Role>> GeEACouncilEntryDetails()
        {
            var powerhouse_Role = await _httpClient.GetFromJsonAsync<PowerHouse_Role[]>(AppSettings.Config.GET_EA_COUNCIL);
            return powerhouse_Role;
            //var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EA_COUNCIL, _httpClient);
            //return entry;
        }
        public async Task<HttpResponseMessage> CreateEACouncilEntryDetails(PowerHouse_Role powerHouse_Role)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.CREATE_POWERHOUSE_ROLE, powerHouse_Role);
            return responseMessage;

            //powerHouse.CreatedOn = DateTime.Now;
            //var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_EA_COUNCIL_ENTRY, _httpClient, powerHouse);
            //return entry;
        }
    }
}
