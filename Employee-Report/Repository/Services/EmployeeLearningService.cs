using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Repository.Services
{
    public class EmployeeLearningService : IEmployeeLearningService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeeLearningService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
       
        public async Task<IEnumerable<EmployeeLearning>> GetEmployeeLearnings()
        {
            var empLearnings = await _httpClient.GetFromJsonAsync<EmployeeLearning[]>(AppSettings.Config.GetEmployeeLearning);
            return empLearnings;
        }

        public async Task<HttpResponseMessage> AddEmployeeLearning(EmployeeLearning empLearning)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddEmployeeLearning, empLearning);
            return responseMessage;
        }

    }
}
