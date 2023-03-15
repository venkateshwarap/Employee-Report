using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Repository.Services
{
    public class EmployeePocService : IEmployeePocService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeePocService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<IEnumerable<EmployeePOCEntity>> GetEmployeePOCDetails()
        {
            var empPoc = await _httpClient.GetFromJsonAsync<EmployeePOCEntity[]>(AppSettings.Config.GetEmployeePOC);
            return empPoc;
        }

        public async Task<HttpResponseMessage> AddEmployeePOC(EmployeePoc employeePoc)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddEmployeePOC, employeePoc);
            return responseMessage;
        }

        public async Task<IEnumerable<Poc>> GetPOCDetails()
        {
            var Poc = await _httpClient.GetFromJsonAsync<Poc[]>(AppSettings.Config.GetPOC);
            return Poc;
        }

        public async Task<HttpResponseMessage> AddPOC(Poc poc)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddPOC, poc);
            return responseMessage;
        }
    }
}
