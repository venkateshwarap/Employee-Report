using Employee_Report.Model.Models;
using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface ILearningService
    {
        Task<Response> GetLearnings();
        Task<Response> AddNewLearning(Learning learning);
    }
}
