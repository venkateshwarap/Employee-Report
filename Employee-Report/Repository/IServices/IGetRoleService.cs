using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IGetRoleService
    {
        Task<IEnumerable<Role>> GetRoleDetails();
        Task<HttpResponseMessage> AddRole(Role role);
    }
}
