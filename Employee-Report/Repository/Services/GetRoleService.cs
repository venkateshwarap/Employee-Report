using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Repository.Services
{
    public class GetRoleService : IGetRoleService
    {
        HttpClient _httpClient = new HttpClient();
        public GetRoleService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<IEnumerable<Role>> GetRoleDetails()
        {
            var role = await _httpClient.GetFromJsonAsync<Role[]>(AppSettings.Config.GetRole);
            return role;
        }

        public async Task<HttpResponseMessage> AddRole(Role role)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddRole, role);
            return responseMessage;
        }
    }
}
