using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IEmpService
    {
        Task<IEnumerable<Employees>> GetEmployee();
        Task<Employees> GetEmployeeById(string Id);

    }
}
