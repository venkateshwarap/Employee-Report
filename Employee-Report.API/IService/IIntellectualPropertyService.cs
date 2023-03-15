using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.API.Service
{
    public interface IIntelleactalProperty
    {
        Task<Response> GetAll();
        Task<Response> GetById(string empid);
        Task<Response> Create(IntellectualProperty intelleactual);
        Task<Response> Update(IntellectualProperty intelleactual);
        Task<Response> Delete(string empid);
    }
}