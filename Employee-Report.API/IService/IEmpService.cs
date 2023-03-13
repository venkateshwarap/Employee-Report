using Employee.DataModel.Models;
using Employee_Report.API.Entities;

namespace Employee_Report.API.IService
{
    public interface IEmpService
    {
        Task<IEnumerable<Employees>> GetEmployee();
        EMP GetEmployeeById(string Id);

    }
}
