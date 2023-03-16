using Employee_Report.Model.Models;
using Employee_Report.Model;
using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IInterviewService
    {
        Task<Response> GetInterviews();
        Task<Response> GetInterviewByID(int id);
        Task<Response> AddInterview(Interview interview);
    }
}
