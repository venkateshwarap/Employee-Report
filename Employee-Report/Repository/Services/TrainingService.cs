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
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_ADMIN_TRAINING, _httpClient);
            return entry;
        }

        public async Task<Response> GetTrainingsById(string Id)
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_ADMIN_TRAINING_BY_ID, Id, _httpClient);
            return entry;
        }
        public async Task<Response> CreateTraining(Training training)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_ADMIN_TRAINING, _httpClient, training);
            return entry;
        }
    }
}
