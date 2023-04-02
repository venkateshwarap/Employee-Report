using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;
using Employee_Report.Model.ModelView;

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


        public async Task<Response> GetAllEACouncilEntryExit()
        {
                var result = await (from ph in _context.PowerHouse
                              join r in _context.Roles on ph.RoleId equals r.Id
                              select new { Id = ph.Id, EmpId = ph.EmpId, StartDate = ph.StartDate, EndDate = ph.EndDate, RoleName = r.RoleName, ReportingTo = ph.ReportingTo }).ToListAsync();

              var result_employee = (from ph in result
                                     join employee in _context.Employees on ph.EmpId equals employee.Id
                                     select new { Id = ph.Id, FirstName = employee!.FirstName, LastName = employee!.LastName, EmpId = ph.EmpId, StartDate = ph.StartDate, EndDate = ph.EndDate, RoleName = ph.RoleName, ReportingTo = ph.ReportingTo }).ToList();

            if (result_employee != null)
            {
                if (result != null)
                {
                    return BindResponse(result_employee!, true);
                }
            }
            return BindResponse(null!, false);
        }
   

        public async Task<Response> GetEACouncilByEmpId(string empid)
        {
            var employee = await _context.Employees.Where(x => x.Id == empid).FirstOrDefaultAsync();
            if (employee!.Id != null)
            {
                var result = await (from ph in _context.PowerHouse
                                    join r in _context.Roles on ph.RoleId equals r.Id
                                    where ph.EmpId == empid
                                    select new { Id = ph.Id, FirstName = employee!.FirstName, LastName = employee!.LastName, EmpId = ph.EmpId, StartDate = ph.StartDate, EndDate = ph.EndDate, RoleName= r.RoleName, ReportingTo = ph.ReportingTo }).ToListAsync();

                if (result != null)
                {
                    if (result != null)
                    {
                        return BindResponse(result!, true);
                    }
                }
            }
            return BindResponse(null!, false);
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
