
using Employee.DataModel.Models;
using Employee_Report.AppSettings;
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
        public async Task<Response> CreateCertificationDetails(Certifications certifications)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_CERTIFICATIONS_DETAILS, _httpClient, certifications);
            return entry;
        }
    }
}
