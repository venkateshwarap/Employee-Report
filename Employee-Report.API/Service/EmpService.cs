using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmpService : IEmpService
    {
        private EmployeeInfoContext _dBContext;

        public EmpService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }
        public async Task<IEnumerable<Employees>> GetEmployee()
        {
            try
            {
                if (_dBContext != null)
                {
                    return await _dBContext.Employees.ToListAsync();
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
          

        }

        public Employees GetEmployeeById(string Id)
        {
            if (_dBContext != null)
            {
                var result = _dBContext.Employees.ToList().Find(x => x.Id == Id);        
                return result;
            }
            return null;
        }
    }
}
