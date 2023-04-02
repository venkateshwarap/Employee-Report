using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EmployeesService : IEmployeesService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeesService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<Response> GetEmployeeDetails()
        {
            var emp = await Utility.HttpClientGetAsync(AppSettings.Config.GetEmployee, _httpClient);
            return emp;
        }

        public async Task<Response> GetEmployeeById(string Id)
        {
            var emp = await Utility.HttpClientGetAsync(AppSettings.Config.GetEmployeeById, Id, _httpClient);
            return emp;
        }
    }
}
