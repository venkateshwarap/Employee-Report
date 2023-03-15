using Employee.DataModel.Models;

namespace Employee_Report.Repository.Services
{
    public class EmployeeSkillService : Repository.IServices.IEmployeeSkillService
    {
        HttpClient _httpClient = new HttpClient();
        public EmployeeSkillService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE);
        }

        public async Task<IEnumerable<EmployeeSkills_Skills_Entity>> GetEmployeeSkills_Skills()
        {
            var empSkills_Skills = await _httpClient.GetFromJsonAsync<EmployeeSkills_Skills_Entity[]>(AppSettings.Config.GetEmployeeSkills);
            return empSkills_Skills;
        }

        public async Task<HttpResponseMessage> AddEmployeeSkills_Skils(EmployeeSkills employeeSkills)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddEmployeeSkill, employeeSkills);
            return responseMessage;
        }
    }
}
