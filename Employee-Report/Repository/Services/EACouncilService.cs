using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EACouncilService : IEACouncilService
    {
        private readonly HttpClient _httpClient;
        public EACouncilService()
        {
            _httpClient =new HttpClient();
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GeEACouncilEntryDetails()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EA_COUNCIL, _httpClient);
            return entry;
        }
        public async Task<Response> CreateEACouncilEntryDetails(EacouncilEntryExit EACouncilEntryExit)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_EA_COUNCIL_ENTRY, _httpClient, EACouncilEntryExit);
            return entry;
        }
    }
}
