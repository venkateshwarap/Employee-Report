using Employee_Report.Model.Models;
using Employee_Report.Model.ModelView;

namespace Employee_Report.API.IService
{
    public interface IPowerHouseService
    {
        Task<Response> CreateCouncilEntry(PowerHouse bench);
        Task<Response> GetAllEACouncilEntryExit();
        Task<Response> GetEACouncilByEmpId(string empid);
        Task<Response> DeleteFromEACouncil(string empid);
    }
}
