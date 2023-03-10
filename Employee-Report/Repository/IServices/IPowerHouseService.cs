using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IPowerHouseService
    {
        Task<Response> GeEACouncilEntryDetails();
        Task<Response> CreateEACouncilEntryDetails(PowerHouse EACouncilEntryExit);
    }
}