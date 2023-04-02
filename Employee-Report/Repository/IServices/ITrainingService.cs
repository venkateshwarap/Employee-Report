using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface ITrainingService
    {
        Task<Response> GetTrainings();
        Task<Response> AddNewTraining(Training training);
        Task<Response> GetTrainingsById(string Id);
    }
}
