using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.IService
{
    public interface IPowerHouseService
    {
        Task<Response> CreateCouncilEntry(PowerHouse bench);
        Task<Response> CreatePowerhouse_Role(PowerHouse_Role powerHouse_Role);
        Task<List<PowerHouse_Role>> GetAllEACouncilEntryExit();
        Task<Response> GetEACouncilByEmpId(string empid);
        Task<Response> DeleteFromEACouncil(string empid);
    }
}
