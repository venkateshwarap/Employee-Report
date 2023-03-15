using Employee.DataModel.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class ReportService
    {
        HttpClient _httpClient = new HttpClient();
        public ReportService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<Response> GetInterviews()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GetInterviews, _httpClient);
            return entry;
        }
        public async Task<Response> GetCertificationDetails()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_CERTIFICATIONS_DETAILS, _httpClient);
            return entry;
        }

        public async Task<Response> GeEACouncilEntryDetails()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EA_COUNCIL, _httpClient);
            return entry;
        }

        public async Task<IEnumerable<EmployeePOCEntity>> GetEmployeePOCDetails()
        {
            var empPoc = await _httpClient.GetFromJsonAsync<EmployeePOCEntity[]>(AppSettings.Config.GetEmployeePOC);
            return empPoc;
        }

        public async Task<IEnumerable<EmployeeProjectEntity>> GetEmployeeProjectDetails()
        {
            var empProject = await _httpClient.GetFromJsonAsync<EmployeeProjectEntity[]>(AppSettings.Config.GetEmployeeProject);
            return empProject;
        }

        public async Task<Response> GetLearnings()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.Getlearnings, _httpClient);
            return entry;
        }

        public async Task<Response> GetTrainings()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GetTrainings, _httpClient);
            return entry;
        }
    }
}
