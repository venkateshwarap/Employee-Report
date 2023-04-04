using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class POCService : IPOCService
    {

        private EmployeeInfoContext _dBContext;

        public POCService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }

        public async Task<Response> GetById(string empId)
        {
            var result = await (from ep in _dBContext.EmployeePocs
                                join p in _dBContext.Pocs on ep.Pocid equals p.Id
                                join e in _dBContext.Employees on ep.EmpId equals e.Id
                                join r in _dBContext.Roles on ep.RoleId equals r.Id
                                select new { EmpId = ep.EmpId, Name = p.Name, Role = r.RoleName, StartDate = ep.StartDate, EndDate = ep.EndDate, ReportingTo = ep.ReportingTo }).ToListAsync();

            if (result != null)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(null!, false);
        }

        public async Task<Response> GetEmployeePOCDetails()
        {
           
            var result = await (from ep in _dBContext.EmployeePocs
                                join p in _dBContext.Pocs on ep.Pocid equals p.Id
                                join r in _dBContext.Roles on ep.RoleId equals r.Id
                                select new {EmpId=ep.EmpId, Name = p.Name, Role= r.RoleName, StartDate = ep.StartDate, EndDate = ep.EndDate, ReportingTo = ep.ReportingTo }).ToListAsync();

            if (result != null)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(null!, false);
        }

        public async Task<Response> GetPOCDetails()
        {
            var result = await _dBContext.Pocs.ToListAsync();
            if (result != null)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(null!, false);
        }

        public async Task<Response> PostEmployeePoc(EmployeePoc employeePoc)
        {

            await _dBContext.EmployeePocs.AddAsync(employeePoc);
            var result = await _dBContext.SaveChangesAsync();
            if (result != 0)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result!, false);
        }

        public async Task<Response> PostPoc(Poc poc)
        {
            await _dBContext.Pocs.AddAsync(poc);
            var result = await _dBContext.SaveChangesAsync();
            if (result != 0)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result!, false);

        }

    }
}
