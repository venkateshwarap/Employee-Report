using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.EntityFrameworkCore;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Service
{
    public class EmpService : IEmpService
    {
        private EmployeeInfoContext _dBContext;

        public EmpService(EmployeeInfoContext context)
        {
           _dBContext = context;
        }
        public async Task<Response> GetEmployee()
        {
           
            var result = await _dBContext.Employees.ToListAsync();
            if(result.Count > 0) 
            { 
            return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result, false);
        }

        public async Task<Response> GetEmployeeById(string Id)
        {
                var result = await _dBContext.Employees.Where(x => x.Id == Id).ToListAsync();  
            if(result.Count > 0)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result, false);
        }
    }
}
