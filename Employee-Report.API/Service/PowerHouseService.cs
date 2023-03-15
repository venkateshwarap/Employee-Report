using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;
namespace Employee_Report.API.Service
{
    public class PowerHouseService : IPowerHouseService
    {
        private EmployeeInfoContext _context;
        public PowerHouseService(EmployeeInfoContext context)
        {
            _context = context;
        }

        public async Task<Response> CreateCouncilEntry(PowerHouse bench)
        {
            await _context.PowerHouse.AddAsync(bench);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Bench_Entry);
            }
            {
                return BindResponse(result, false, Constants.Response_Bench_Entry_Failed);
            }
        }


        public async Task<List<PowerHouse_Role>> GetAllEACouncilEntryExit()
        {
            var powerHouseDetails = new List<PowerHouse_Role>();
            if (_context != null)
            {
                var result = (from ph in _context.PowerHouse
                              join r in _context.Roles on ph.RoleId equals r.Id
                              select new { ph.Id, ph.EmpId, ph.StartDate, ph.EndDate, r.RoleName, ph.ReportingTo }).ToList();

                if (result != null)
                {
                    foreach (var res in result)
                    {
                        powerHouseDetails.Add(new PowerHouse_Role
                        {
                            Id = res.Id,
                            EmpId = res.EmpId,
                            RoleName = res.RoleName,
                            StartDate = res.StartDate,
                            EndDate = res.EndDate,
                            ReportingTo = res.ReportingTo
                        });
                    }
                }
            }
            return powerHouseDetails;

            #region Try
            //var result = (from ph in _context.PowerHouse
            //              join r in _context.Roles on ph.RoleId equals r.Id
            //              select new { ph.Id, ph.EmpId, ph.StartDate, ph.EndDate, r.RoleName, ph.ReportingTo }).ToList();

            //PowerHouse_Role phRole = new PowerHouse_Role();
            //foreach(var data in result)
            //{
            //    phRole.Id = data.Id;
            //    phRole.EmpId = data.EmpId;
            //    phRole.StartDate = data.StartDate;
            //    phRole.EndDate = data.EndDate;
            //    phRole.RoleName = data.RoleName;
            //    phRole.ReportingTo = data.ReportingTo;
            //};
            //return result;
            #endregion
        }

        public async Task<Response> GetEACouncilByEmpId(string empid)
        {
            var result = await _context.PowerHouse.Where(x => x.EmpId == empid).FirstOrDefaultAsync();
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
            var result = await _context.PowerHouse.Where(x => x.EmpId == empid).FirstOrDefaultAsync();
            if (result == null)
            {
                return BindResponse(result!, false, Constants.RE_EmpId_Not_Available_EA);
            }
            _context.PowerHouse.Remove(result!);
            var response = await _context.SaveChangesAsync();

            if (response == 1)
            {
                return BindResponse(result!, true, Constants.RE_Remove_EA);
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
