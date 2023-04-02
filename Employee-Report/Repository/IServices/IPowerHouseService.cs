using Employee_Report.Model.Models;
using Employee_Report.Model.ModelView;

namespace Employee_Report.Repository.IServices
{
    public interface IPowerHouseService
    {
        Task<Response> GeEACouncilEntryDetails();
        Task<Response> CreateEACouncilEntryDetails(PowerHouseRoleView powerHouse_Role);
        Task<Response> GetPowerHouseById(string Id);
    }
}