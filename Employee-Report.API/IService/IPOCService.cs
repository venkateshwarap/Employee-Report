using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IPOCService
    {
        Task<List<Poc>> GetPOCDetails();

        Task<List<EmployeePOCEntity>> GetEmployeePOCDetails();

        Task<int> PostPoc(Poc poc);
        Task<int> PostEmployeePoc(EmployeePoc employeePoc);
        Response GetById(string empId);
    }
}
