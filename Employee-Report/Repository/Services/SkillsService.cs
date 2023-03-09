﻿using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class SkillsService : ISkillsService
    {
        HttpClient _httpClient = new HttpClient();
        public SkillsService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<string> GetSkills()
        {
            var entry = await Utility.HttpClientGetStringAsync(AppSettings.Config.GetSkills, _httpClient);
            return entry;
        }
        public async Task<Response> AddSkill(Skills skill)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.AddSkill, _httpClient, skill);
            return entry;
        }
    }
}
