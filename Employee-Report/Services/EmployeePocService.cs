using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Services
{
    public class EmployeePocService
    {
        private readonly HttpClient _httpClient;
        public EmployeePocService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EmployeePOCEntity>> GetEmployeePOCDetails()
        {
            var empPoc = await _httpClient.GetFromJsonAsync<EmployeePOCEntity[]>(AppSettings.GetPOC);
            return empPoc;
        }

        public async Task<HttpResponseMessage> AddPOC(EmployeePoc employeePoc)
        {
           HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.AddPOC, employeePoc);
            return responseMessage;
        }
    }
}
