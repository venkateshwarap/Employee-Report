﻿using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Services
{
    public class GetRoleService
    {
        private readonly HttpClient _httpClient;
        public GetRoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Role>> GetRoleDetails()
        {
            var role = await _httpClient.GetFromJsonAsync<Role[]>(AppSettings.GetRole);
            return role;
        }

        public async Task<HttpResponseMessage> AddRole(Role role)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.AddRole, role);
            return responseMessage;
        }
    }
}
