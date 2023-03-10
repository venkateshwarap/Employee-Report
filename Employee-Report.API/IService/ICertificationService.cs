using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface ICertificationService
    {
        Task<Response> CreateCertificationDetails(Certification certifications);
        Task<Response> GetCertificationDetails();
        Task<Response> GetCertificationDetailsById(string empid);
        Task<Response> Delete(string empid);
    }
}
