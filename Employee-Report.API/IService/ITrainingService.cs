using Employee.DataModel.Models;
using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface ITrainingService
    {
        Task<Response> GetTrainings();
        Task<Response> AddNewTraining(Training training);
        Task<Response> GetTrainingById(string Id);
    }
}
