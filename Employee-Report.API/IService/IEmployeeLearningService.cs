using Employee.DataModel.Models;
using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface IEmployeeLearningService
    {
        Task<Response> CreateEmployeeLearning(EmployeeLearning learning);
        Response GetEmployeelearningDetails();
        Task<Response> GetEmployeeLearningbyEmpId(string empId);
    }
}
