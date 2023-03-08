using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeePocService
    {
        Task<IEnumerable<EmployeePOCEntity>> GetEmployeePOCDetails();
        Task<HttpResponseMessage> AddEmployeePOC(EmployeePoc employeePoc);
        Task<IEnumerable<Poc>> GetPOCDetails();
        Task<HttpResponseMessage> AddPOC(Poc poc);
    }
}
