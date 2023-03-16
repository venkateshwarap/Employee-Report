using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;
using System.Net.Http.Json;

namespace Employee_Report.Repository.Services
{
    public class EmployeesService : IEmployeesService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeesService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<IEnumerable<Employees>> GetEmployeeDetails()
        {
            var emp = await _httpClient.GetFromJsonAsync<Employees[]>(AppSettings.Config.GetEmployee);
            return emp;
        }
       
        public async Task<EMP> GetEmployeeById(string Id)
        {
            var emp = await _httpClient.GetFromJsonAsync<EMP>(AppSettings.Config.GetEmployeeById);
            return emp;
        }
    }
}
