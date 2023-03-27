using Employee.DataModel.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IPowerHouseService
    {
        Task<IEnumerable<PowerHouse_Role>> GeEACouncilEntryDetails();
        Task<HttpResponseMessage> CreateEACouncilEntryDetails(PowerHouse_Role powerHouse_Role);
        Task<Response> GetPowerHouseById(string Id);
    }
}