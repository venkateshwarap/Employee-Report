using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class InterviewService : IInterviewService
    {
        HttpClient _httpClient = new HttpClient();
        public InterviewService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetInterviews()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GetInterviews, _httpClient);
            return entry;
        }
        public async Task<Response> AddInterview(Interview interview)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.AddInterviews, _httpClient, interview);
            return entry;
        }
    }
}
