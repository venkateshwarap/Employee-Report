using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Employee_Report.API.Service
{
    public class POCService : IPOCService
    {

        private EatrackingContext _dBContext;

        public POCService(EatrackingContext context)
        {
            this._dBContext = context;
        }
        public async Task<List<EmployeePOCEntity>> GetEmployeePOCDetails()
        {
            var empPOCDetails = new List<EmployeePOCEntity>();
            if (_dBContext != null)
            {
                var result = (from ep in _dBContext.EmployeePocs
                              join p in _dBContext.Pocs on ep.Pocid equals p.Id
                              join r in _dBContext.Roles on ep.RoleId equals r.Id
                              select new {p.Name, r.RoleName, ep.StartDate, ep.EndDate, ep.ReportingTo }).ToList();

                if (result != null)
                {
                    foreach (var emp in result)
                    {
                        empPOCDetails.Add( new EmployeePOCEntity { 
                            
                            Name= emp.Name,
                            Role = emp.RoleName,
                            StartDate= emp.StartDate,
                            EndDate= emp.EndDate,
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
