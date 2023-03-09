using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EmployeeSkillsService : IEmployeeSkillsService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeeSkillsService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetEmployeeSkills()
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GetEmployeeSkills, _httpClient);
            return entry;
        }
        public async Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkill)
        {
            var entry = await Utility.HttpClientPostAsync(AppSettings.Config.AddEmployeeSkill, _httpClient, employeeSkill);
            return entry;
        }
    }
}
