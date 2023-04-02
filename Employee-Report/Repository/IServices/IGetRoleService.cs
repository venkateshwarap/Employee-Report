using Employee_Report.Model.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IGetRoleService
    {
        Task<Response> GetRoleDetails();
        Task<Response> AddRole(Role role);
    }
}
