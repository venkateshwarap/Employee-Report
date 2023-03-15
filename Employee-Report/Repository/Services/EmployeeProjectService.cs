using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Repository.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
       
        HttpClient _httpClient = new HttpClient();
        public EmployeeProjectService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<IEnumerable<EmployeeProjectEntity>> GetEmployeeProjectDetails()
        {
            var empProject = await _httpClient.GetFromJsonAsync<EmployeeProjectEntity[]>(AppSettings.Config.GetEmployeeProject);
            return empProject;
        }
        public async Task<HttpResponseMessage> AddEmployeeProject(EmployeeProject project)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddEmployeeProject, project);
            return responseMessage;
        }

        public async Task<IEnumerable<Project>> GetProjectDetails()
        {
            var empProject = await _httpClient.GetFromJsonAsync<Project[]>(AppSettings.Config.GetProject);
            return empProject;
        }

        public async Task<HttpResponseMessage> AddProject(Project project)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(AppSettings.Config.AddProject, project);
            return responseMessage;
        }
    }
}
