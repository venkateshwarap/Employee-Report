using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface ILearningService
    {
        Task<Response> GetLearnings();
        Task<Response> CreateLearning(Learning learning);

    }
}
