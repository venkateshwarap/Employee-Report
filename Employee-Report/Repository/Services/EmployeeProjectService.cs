using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Repository.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly HttpClient _httpClient;
        public EmployeeProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EmployeeProjectEntity>> GetEmployeeProjectDetails()
        {
            var empProject = await _httpClient.GetFromJsonAsync<EmployeeProjectEntity[]>(AppSettings.GetEmployeeProject);
            return empProject;
        }

        //public async Task<HttpResponseMessage> AddProject(EmployeeProject employeeProject)
        //{
        //    HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.AddPOC, employeeProject);
        //    return responseMessage;
        //}

        public async Task<HttpResponseMessage> AddEmployeeProject(EmployeeProject project)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.AddProject, project);
            return responseMessage;
        }
    }
}
