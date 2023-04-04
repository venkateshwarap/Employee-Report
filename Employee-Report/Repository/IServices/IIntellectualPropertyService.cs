using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IIntellectualPropertyService
    {
        Task<Response> GetIntelleactualProperty();
        Task<Response> CreateIntelleactualProperty(IntellectualProperty intelleactual);
    }
}
