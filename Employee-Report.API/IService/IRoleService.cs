using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IRoleService
    {
        Task<List<Role>> GetRoleDetails();
        Task<int> PostRole(Role role);

    }
}
