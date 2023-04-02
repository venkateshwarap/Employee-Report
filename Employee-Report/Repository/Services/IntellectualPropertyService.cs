using Employee_Report.Model.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class IntellectualPropertyService : IIntellectualPropertyService
    {
        private readonly HttpClient _httpClient;
        public IntellectualPropertyService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetIntelleactualProperty()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_INTELLECTUAL_PROPERTY_DETAILS, _httpClient);
            return entry;
        }
        public async Task<Response> CreateIntelleactualProperty(IntellectualProperty intelleactual)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_INTELLECTUAL_PROPERTY_DETAILS, _httpClient, intelleactual);
            return entry;
        }
    }
}
