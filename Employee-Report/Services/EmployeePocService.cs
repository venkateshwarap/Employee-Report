using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Repository.Services
{
    public class EmployeePocService : IEmployeePocService
    {
        private readonly HttpClient _httpClient;
        public EmployeePocService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EmployeePOCEntity>> GetEmployeePOCDetails()
        {
            var empPoc = await _httpClient.GetFromJsonAsync<EmployeePOCEntity[]>(AppSettings.Config.GetPOC);
            return empPoc;
        }

        public async Task<HttpResponseMessage> AddPOC(EmployeePoc employeePoc)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddPOC, employeePoc);
            return responseMessage;
        }
    }
}
