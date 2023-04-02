using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EmployeeLearningService : IEmployeeLearningService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeeLearningService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
       
        public async Task<Response> GetEmployeeLearnings()
        {
            var empLearnings = await Utility.HttpClientGetAsync(AppSettings.Config.GetEmployeeLearning,_httpClient);
            return empLearnings;
        }

        public async Task<Response> GetEmployeeLearningById(string empId)
        {
            var empLearnings = await Utility.HttpClientGetAsync("EmployeeLearning/getById?empID=MLI740", empId, _httpClient);
            return empLearnings;
        }

        public async Task<HttpResponseMessage> AddEmployeeLearning(EmployeeLearning empLearning)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddEmployeeLearning, empLearning);
            return responseMessage;
        }

    }
}
