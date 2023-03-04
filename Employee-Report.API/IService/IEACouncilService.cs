using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.IService
{
    public interface IEACouncilService
    {
        Task<Response> CreateCouncilEntry(EACouncilEntryExit bench);
        Task<Response> GetAllEACouncilEntryExit();
        Task<Response> GetEACouncilByEmpId(string empid);
        Task<Response> DeleteFromEACouncil(string empid);
    }
}
