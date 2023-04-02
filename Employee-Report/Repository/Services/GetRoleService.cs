using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;
using System.Net.Http.Json;

namespace Employee_Report.Repository.Services
{
    public class GetRoleService : IGetRoleService
    {
        HttpClient _httpClient = new HttpClient();
        public GetRoleService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }

        public async Task<Response> GetRoleDetails()
        {
            var role = await Utility.HttpClientGetAsync(AppSettings.Config.GetRole, _httpClient);
            return role;
        }

        public async Task<Response> AddRole(Role role)
        {
            var response = await Utility.HttpClientPostAsync(AppSettings.Config.AddRole, _httpClient, role);
            return response;
        }
    }
}

