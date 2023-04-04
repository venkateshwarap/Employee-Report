using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EmployeePocService : IEmployeePocService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeePocService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<Response> GetEmployeePOCDetails()
        {
            var empPoc = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_POC, _httpClient);
            return empPoc;
        }

        public async Task<Response> AddEmployeePOC(EmployeePoc employeePoc)
        {
            var response = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_EMPLOYEE, _httpClient, employeePoc);
            return response;
        }

        public async Task<Response> GetPOCDetails()
        {
            var Poc = await Utility.HttpClientGetAsync(AppSettings.Config.GET_ADMIN_POC, _httpClient);
            return Poc;
        }

        public async Task<Response> AddPOC(Poc poc)
        {
            var response = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_ADMIN_POC, _httpClient, poc);
            return response;
        }
        public async Task<Response> GetEmployeePOCById(string Id)
        {
            var empPoc = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_POC_ID, Id, _httpClient);
            return empPoc;
        }
    }
}

