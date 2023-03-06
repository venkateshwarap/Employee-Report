using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class RoleService : IRoleService
    {
        private EatrackingContext _dBContext;

        public RoleService(EatrackingContext context)
        {
            this._dBContext = context;
        }
        public async Task<List<Role>> GetRoleDetails()
        {
            if (_dBContext != null)
            {
                return await _dBContext.Roles.ToListAsync();
            }
            return null;
        }

        public async Task<int> PostRole(Role role)
        {
            if (_dBContext != null)
            {
                await _dBContext.Roles.AddAsync(role);
                await _dBContext.SaveChangesAsync();
                return role.Id;
            }
            return 0;
        }
    }
}
