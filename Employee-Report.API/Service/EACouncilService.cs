﻿using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;
namespace Employee_Report.API.Service
{
    public class EACouncilService : IEACouncilService
    {
        private EatrackingContext _context;
        public EACouncilService(EatrackingContext context)
        {
            _context = context;
        }

        public async Task<Response> CreateCouncilEntry(EacouncilEntryExit bench)
        {
            await _context.EacouncilEntryExits.AddAsync(bench);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Bench_Entry);
            }
            {
                return BindResponse(result, false, Constants.Response_Bench_Entry_Failed);
            }
        }


        public async Task<Response> GetAllEACouncilEntryExit()
        {
            var result = await _context.EacouncilEntryExits.ToListAsync();
            if (result.Count > 0)
            {
                return BindResponse(result, true);
            }
            {
                return BindResponse(result, false);
            }
        }

        public async Task<Response> GetEACouncilByEmpId(string empid)
        {
            var result = await _context.EacouncilEntryExits.Where(x=>x.EmpId == empid).FirstOrDefaultAsync();
            if (result != null)
            {
                return BindResponse(result!, true);
            }
            {
                return BindResponse(result!, false);
            }
        }

        public async Task<Response> DeleteFromEACouncil(string empid)
        {
            var result = await _context.EacouncilEntryExits.Where(x=>x.EmpId == empid).FirstOrDefaultAsync();
            if (result == null)
            {
                return BindResponse(result!, false, Constants.RE_EmpId_Not_Available_EA);
            }
            _context.EacouncilEntryExits.Remove(result!);
            var response = await _context.SaveChangesAsync();

            if (response == 1)
            {
                return BindResponse(result!, true,Constants.RE_Remove_EA);
            }
            {
                return BindResponse(result!, false);
            }
        }
        public Response BindResponse(Object Obj = null!, bool Status = true, string Message = "")
        {
            Response resp = new Response();
            resp.response = Obj;
            resp.message = Message;
            resp.status = Status;
            return resp;
        }
    }
}
