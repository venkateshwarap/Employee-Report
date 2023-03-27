using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface ILearningService
    {
        Task<Response> GetLearnings();
        Task<Response> AddNewLearning(Learning learning);

        Task<Response> GetLearningsById(string Id);
    }
}
