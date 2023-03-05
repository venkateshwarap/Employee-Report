using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using EmployeeDetails.Api.Utilities;
using Syncfusion.Blazor.PivotView.Internal;

namespace Employee_Report.Services
{
    public class InterviewService
    {
        private readonly HttpClient _httpClient;
        public InterviewService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
