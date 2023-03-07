using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using EmployeeDetails.Api.Utilities;

namespace Employee_Report.Repository.Services
{
    public class InterviewService : IInterviewService
    {
        HttpClient _httpClient = new HttpClient();
        public InterviewService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.BaseUrl!);
        }
        public async Task<Response> GetInterviews()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.GetInterviews, _httpClient);
            return entry;
        }
        public async Task<Response> AddInterview(Interview interview)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.AddInterviews, _httpClient, interview);
            return entry;
        }
    }
}
