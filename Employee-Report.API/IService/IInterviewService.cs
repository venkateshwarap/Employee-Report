using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IInterviewService
    {
        Task<Response> GetInterviews();
        Task<Response> GetInterviewByID(int id);
        Task<Response> AddInterview(Interview interview);
    }
}
