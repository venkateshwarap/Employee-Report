using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IPOCService
    {
        Task<Response> GetPOCDetails();

        Task<Response> GetEmployeePOCDetails();

        Task<Response> PostPoc(Poc poc);
        Task<Response> PostEmployeePoc(EmployeePoc employeePoc);
        Task<Response> GetById(string empId);
    }
}
