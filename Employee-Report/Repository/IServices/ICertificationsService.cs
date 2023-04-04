using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface ICertificationsService
    {
        Task<Response> GetCertificationDetails();
        Task<Response> CreateCertificationDetails(Certification certifications);
        Task<Response> GetCertificationById(string empid);
    }
}