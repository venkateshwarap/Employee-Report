using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class LearningService : ILearningService
    {
        HttpClient _httpClient = new HttpClient();
        public LearningService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetLearnings()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.Getlearnings, _httpClient);
            return entry;
        }

        public async Task<Response> GetLearningsById(string Id)
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_LEARNING_ID,Id, _httpClient);
            return entry;
        }
        public async Task<Response> AddNewLearning(Learning learning)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.AddNewLearning, _httpClient, learning);
            return entry;
        }
    }
}
