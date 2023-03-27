using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Employee_Report.API.Service
{
    public class POCService : IPOCService
    {

        private EmployeeInfoContext _dBContext;

        public POCService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }

        public Response GetById(string empId)
        {
            if (_dBContext != null)
            {
                //var result = _dBContext.Employees.ToList().Find(x => x.Id == Id);

                var result = (from ep in _dBContext.EmployeePocs
                              join e in _dBContext.Employees on ep.EmpId equals e.Id
                              join p in _dBContext.Pocs on ep.Pocid equals p.Id
                              where e.Id == empId
                              select new { p.Name, ep.EmpId, ep.Pocid, ep.StartDate, ep.EndDate, ep.ReportingTo }).ToList();


                List<EmployeePOCEntity> employeePOCEntity = new List<EmployeePOCEntity>();

                foreach (var li in result)
                {
                    employeePOCEntity.Add(new EmployeePOCEntity
                    {
                        Name = li.Name,
                        EmpId = li.EmpId,
                        EndDate = li.EndDate,
                        ReportingTo = li.ReportingTo,
                        StartDate = li.StartDate
                    });
                }

                return APIUtility.BindResponse(employeePOCEntity,true);
            }
            return APIUtility.BindResponse(null!, false);

        }

        public async Task<List<EmployeePOCEntity>> GetEmployeePOCDetails()
        {
            var empPOCDetails = new List<EmployeePOCEntity>();
            if (_dBContext != null)
            {
                var result = (from ep in _dBContext.EmployeePocs
                              join p in _dBContext.Pocs on ep.Pocid equals p.Id
                              join r in _dBContext.Roles on ep.RoleId equals r.Id
                              select new { p.Name, r.RoleName, ep.StartDate, ep.EndDate, ep.ReportingTo }).ToList();

                if (result != null)
                {
                    foreach (var emp in result)
                    {
                        empPOCDetails.Add(new EmployeePOCEntity
                        {

                            Name = emp.Name,
                            Role = emp.RoleName,
                            StartDate = emp.StartDate,
                            EndDate = emp.EndDate,
                            ReportingTo = emp.ReportingTo
                        });
                    }
                }

            }
            return empPOCDetails;
        }

        public async Task<List<Poc>> GetPOCDetails()
        {
            if (_dBContext != null)
            {
                return await _dBContext.Pocs.ToListAsync();
            }
            return null;
        }

        public async Task<int> PostEmployeePoc(EmployeePoc employeePoc)
        {
            if (_dBContext != null)
            {
                await _dBContext.EmployeePocs.AddAsync(employeePoc);
                await _dBContext.SaveChangesAsync();
                return employeePoc.Id;
            }
            return 0;
        }

        public async Task<int> PostPoc(Poc poc)
        {
            if (_dBContext != null)
            {
                await _dBContext.Pocs.AddAsync(poc);
                await _dBContext.SaveChangesAsync();
                return poc.Id;
            }
            return 0;

        }

    }
}
