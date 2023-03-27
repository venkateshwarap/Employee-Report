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

        public async Task<Response> GetCertificationById(string empid)
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_CERTIFICATIONS_DETAILS_BY_ID, empid, _httpClient);
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

        public async Task<Response> GetEmployeePOCById(string Id)
        {
            var empPoc = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_POC_ID, Id, _httpClient);
            return empPoc;
        }


        public async Task<IEnumerable<EmployeeProjectEntity>> GetEmployeeProjectDetails()
        {
            var empProject = await _httpClient.GetFromJsonAsync<EmployeeProjectEntity[]>(AppSettings.Config.GetEmployeeProject);
            return empProject;
        }
        public async Task<Response> GetEmployeeProjectDetailsById(string Id)
        {
            var empProject = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_PROJECT_BY_ID, Id, _httpClient);
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
