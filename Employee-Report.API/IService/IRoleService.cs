using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IRoleService
    {
        Task<List<Role>> GetRoleDetails();
        Task<int> PostRole(Role role);

    }
}
