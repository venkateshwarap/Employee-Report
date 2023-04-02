using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeesService
    {
        Task<Response> GetEmployeeDetails();
        Task<Response> GetEmployeeById(string Id);
    }
}
