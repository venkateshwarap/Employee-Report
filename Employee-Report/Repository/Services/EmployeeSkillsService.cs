using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeeSkillService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE);
        }

        public async Task<Response> GetEmployeeSkills()
        {
            var response = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_SKILLS, _httpClient);
            return response;
        }

        public async Task<Response> CreateEmployeeSkill(EmployeeSkills employeeSkills)
        {
            var  responseMessage = await Utility.HttpClientPostAsync(AppSettings.Config.CREATE_EMPLOYEE_SKILLS, _httpClient, employeeSkills);
            return responseMessage;
        }
        public async Task<Response> GetEmployeeSkillsById(string empid)
        {
            var entry = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_SKILLS_BY_ID, empid, _httpClient);
            return entry;
        }
    }
}
