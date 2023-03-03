using Employee_Report.Model.Models;
using Employee_Report.Model;

namespace Employee_Report.API.IService
{
    public interface IInterviewService
    {
        Task<List<Interview>> GetInterviewDeatils();
        ResponseModel AddInterviews(Interview interview);
    }
}
