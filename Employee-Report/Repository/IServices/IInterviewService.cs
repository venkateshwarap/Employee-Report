using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IInterviewService
    {
        Task<Response> GetInterviews();
        Task<Response> CreateInterview(Interview interview);
    }
}
