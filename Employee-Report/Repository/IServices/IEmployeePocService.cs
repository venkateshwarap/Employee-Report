using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeePocService
    {
        Task<Response> GetEmployeePOCDetails();
        Task<Response> AddEmployeePOC(EmployeePoc employeePoc);
        Task<Response> GetPOCDetails();
        Task<Response> AddPOC(Poc poc);
        Task<Response> GetEmployeePOCById(string Id);
    }
}
