using Employee.DataModel.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeLearningService
    {
        Task<IEnumerable<EmployeeLearning>> GetEmployeeLearnings();
        Task<HttpResponseMessage> AddEmployeeLearning(EmployeeLearning empLearning);
    }
}
