using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.API.IService;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmpService : IEmpService
    {
        private EatrackingContext _dBContext;

        public EmpService(EatrackingContext context)
        {
            this._dBContext = context;
        }
        public async Task<IEnumerable<Employees>> GetEmployee()
        {
            if (_dBContext != null)
            {
                return await _dBContext.Employees.ToListAsync();
            }
            return null;
            
        }

        public async Task<Employees> GetEmployeeById(string Id)
        {
            if (_dBContext != null)
            {
                var result= await _dBContext.Employees.FirstOrDefaultAsync();
                return result;
            }
            return null;
        }
    }
}
