using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeLearningService
    {
        Task<Response> GetEmployeeLearnings();
        Task<HttpResponseMessage> AddEmployeeLearning(EmployeeLearning empLearning);
        Task<Response> GetEmployeeLearningById(string empId);
    }
}
