using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IPowerHouseService
    {
        Task<IEnumerable<PowerHouse_Role>> GeEACouncilEntryDetails();
        Task<HttpResponseMessage> CreateEACouncilEntryDetails(PowerHouse_Role powerHouse_Role);
    }
}