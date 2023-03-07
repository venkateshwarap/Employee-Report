using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEACouncilService
    {
        Task<Response> GeEACouncilEntryDetails();
        Task<Response> CreateEACouncilEntryDetails(EACouncilEntryExit EACouncilEntryExit);
    }
}