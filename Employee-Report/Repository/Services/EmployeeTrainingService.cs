using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;


namespace Employee_Report.Repository.Services
{
    public class EmployeeTrainingService : IEmployeeTraining
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeeTrainingService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.EmployeeTraining);
        }

        public Task<IEnumerable<EmployeeTrainingEntity>> GetEmployeeTrainingDetails()
        {
            var trainingInfo = await _httpClient.GetFromJsonAsync<EmployeeTrainingEntity[]>(AppSettings.Config.EmployeeTraining);
            return trainingInfo;
        }
        public Task<EmployeeTrainingEntity> GetEmployeeTrainingById(string Id)
        {
            var trainingInfo = await _httpClient.GetFromJsonAsync<EmployeeTrainingEntity[]>(AppSettings.Config.EmployeeTrainingbyID);
            return trainingInfo;
        }

        public int AddEmployeeTrainingById(EmployeeTraining employeeTraining)
        {
            var trainingInfo = await _httpClient.GetFromJsonAsync<EmployeeTraining[]>(AppSettings.Config.AddNewTraining);
            return trainingInfo;
        }
    }
}
}
