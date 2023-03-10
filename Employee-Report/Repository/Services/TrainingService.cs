using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class TrainingService : ITrainingService
    {
        HttpClient _httpClient = new HttpClient();
        public TrainingService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetTrainings()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GetTrainings, _httpClient);
            return entry;
        }
        public async Task<Response> AddNewTraining(Training training)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.AddNewTraining, _httpClient, training);
            return entry;
        }
    }
}
