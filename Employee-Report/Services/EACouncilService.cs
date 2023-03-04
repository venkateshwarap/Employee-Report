﻿using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using EmployeeDetails.Api.Utilities;

namespace Employee_Report.Services
{
    public class EACouncilService 
    {
        private readonly HttpClient _httpClient;
        public EACouncilService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(AppSettings.BaseUrl!);
        }
        public async Task<Response> GetBenchEntry()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.GetBenchEntry, _httpClient);
            return entry;
        }
        public async Task<Response> CreateBenchEntry(EACouncilEntryExit EACouncilEntryExit)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.CreateBenchEntry, _httpClient, EACouncilEntryExit);
            return entry;
        }
    }
}
