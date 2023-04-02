
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class CertificationsService: ICertificationsService
    {
        private readonly HttpClient _httpClient;
        public CertificationsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetCertificationDetails()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_CERTIFICATIONS_DETAILS, _httpClient);
            return entry;
        }
        public async Task<Response> CreateCertificationDetails(Certification certifications)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_CERTIFICATIONS_DETAILS, _httpClient, certifications);
            return entry;
        }

        public async Task<Response> GetCertificationById(string empid)
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_CERTIFICATIONS_DETAILS_BY_ID, empid, _httpClient);
            return entry;
        }
    }
}
