using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IEmpService
    {
        Task<Response> GetEmployee();
        Task<Response> GetEmployeeById(string Id);

    }
}
