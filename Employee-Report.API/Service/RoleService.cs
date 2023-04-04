using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.EntityFrameworkCore;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Service
{
    public class RoleService : IRoleService
    {
        private EmployeeInfoContext _dBContext;

        public RoleService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }
        public async Task<Response> GetRoleDetails()
        {
           var result = await _dBContext.Roles.ToListAsync();
            if(result.Count > 0)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result, false);
        }

        public async Task<Response> CreateRole(Role role)
        {
                await _dBContext.Roles.AddAsync(role);
               var result = await _dBContext.SaveChangesAsync();
            if (result != 0)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result, false);
        }
    }
}
