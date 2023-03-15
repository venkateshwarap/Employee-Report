using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IPowerHouseService
    {
        Task<Response> CreateCouncilEntry(PowerHouse bench);
        Task<List<PowerHouse_Role>> GetAllEACouncilEntryExit();
        Task<Response> GetEACouncilByEmpId(string empid);
        Task<Response> DeleteFromEACouncil(string empid);
    }
}
