using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IRoleService
    {
        Task<Response> GetRoleDetails();
        Task<Response> CreateRole(Role role);

    }
}
