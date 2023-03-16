using Employee.DataModel.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employees>> GetEmployeeDetails();
        Task<EMP> GetEmployeeById(string Id);
    }
}
