using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class ReportService 
    {
        HttpClient _httpClient = new HttpClient();
        public ReportService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
    }
}
