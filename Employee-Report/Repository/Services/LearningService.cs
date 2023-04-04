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
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_ADMIN_LEARNING, _httpClient);
            return entry;
        }
        public async Task<Response> CreateLearning(Learning learning)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_ADMIN_LEARNING, _httpClient, learning);
            return entry;
        }
    }
}
