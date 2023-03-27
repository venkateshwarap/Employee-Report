using Employee.DataModel.Models;
using employee_report.api.iservice;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class ProjectService : IProjectService
    {
        private EmployeeInfoContext _dBContext;

        public ProjectService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }
        public async Task<List<Project>> GetProjectDetails()
        {
            if (_dBContext != null)
            {
                return await _dBContext.Projects.ToListAsync();
            }
            return null;
        }

        public async Task<List<EmployeeProjectEntity>> GetEmployeeProjectDetails()
        {
            var empProjectDetails = new List<EmployeeProjectEntity>();
            if (_dBContext != null)
            {
                var result = (from ep in _dBContext.EmployeeProjects
                              join p in _dBContext.Projects on ep.ProjectId equals p.Id
                              join r in _dBContext.Roles on ep.RoleId equals r.Id
                              select new { p.ProjectName ,r.RoleName, ep.ReportingTo, ep.StartDate, ep.EndDate }).ToList();

                if (result != null)
                {
                    foreach (var emp in result)
                    {
                        empProjectDetails.Add(new EmployeeProjectEntity
                        {
                            Role = emp.RoleName,
                            Name = emp.ProjectName,
                            StartDate = emp.StartDate,
                            EndDate = emp.EndDate,
                            ReportingTo = emp.ReportingTo
                        });
                    }
                }

            }
            return empProjectDetails;
        }
        public List<EmployeeProjectEntity> GetById(string empId)
        {
            if (_dBContext != null)
            {

                var result = (from ep in _dBContext.EmployeeProjects
                              join e in _dBContext.Employees on ep.EmpId equals e.Id
                              join p in _dBContext.Projects on ep.ProjectId equals p.Id
                              where e.Id == empId
                              select new { p.ProjectName, ep.EmpId, ep.ProjectId, ep.StartDate, ep.EndDate, ep.ReportingTo }).ToList();


                List<EmployeeProjectEntity> employeeProjectEntity = new List<EmployeeProjectEntity>();

                foreach (var li in result)
                {
                    employeeProjectEntity.Add(new EmployeeProjectEntity
                    {
                        Name = li.ProjectName,
                        EmpId = li.EmpId,
                        EndDate = li.EndDate,
                        ReportingTo = li.ReportingTo,
                        StartDate = li.StartDate
                    });
                }

                return employeeProjectEntity;
            }
            return null;

        }
        public async Task<int> PostProject(Project project)
        {
            if (_dBContext != null)
            {

                await _dBContext.Projects.AddAsync(project);
                await _dBContext.SaveChangesAsync();
                return project.Id;
            }
            return 0;
        }

        public async Task<int> PostEmployeeProject(EmployeeProject employeeProject)
        {
            if (_dBContext != null)
            {
                await _dBContext.EmployeeProjects.AddAsync(employeeProject);
                await _dBContext.SaveChangesAsync();
                return employeeProject.Id;
            }
            return 0;
        }

        public async Task<Response> GetByProjectId(string EmpId)
        {
            var result = await _dBContext.EmployeeProjects.Where(x => x.EmpId == EmpId).ToListAsync();
            if (result != null)
            {
                return BindResponse(result!, true);
            }
            {
                return BindResponse(result!, false);
            }

        }
        private Response BindResponse(Object Obj = null!, bool Status = true, string Message = "")
        {
            Response resp = new Response();
            resp.response = Obj;
            resp.message = Message;
            resp.status = Status;
            return resp;
        }
    }
}
