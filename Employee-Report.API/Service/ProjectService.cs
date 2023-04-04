using Employee_Report.Model.Models;
using employee_report.api.iservice;
using Microsoft.EntityFrameworkCore;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Service
{
    public class ProjectService : IProjectService
    {
        private EmployeeInfoContext _dBContext;

        public ProjectService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }
        public async Task<Response> GetProjectDetails()
        {
            var result = await _dBContext.Projects.ToListAsync();
            if (result.Count > 0)
                return APIUtility.BindResponse(result, true);
            return APIUtility.BindResponse(result, false);
        }

        public async Task<Response> GetEmployeeProjectDetails()
        {
            var empProjectDetails = new List<EmployeeProjectEntity>();
            if (_dBContext != null)
            {
                var result = await (from ep in _dBContext.EmployeeProjects
                              join p in _dBContext.Projects on ep.ProjectId equals p.Id
                              join r in _dBContext.Roles on ep.RoleId equals r.Id
                              select new { p.ProjectName ,r.RoleName, ep.ReportingTo, ep.StartDate, ep.EndDate }).ToListAsync();

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
                    return APIUtility.BindResponse(result, true);
                }

            }
            return APIUtility.BindResponse(null!, false);
        }
        public async Task<Response> GetById(string empId)
        {

                var result = await (from ep in _dBContext.EmployeeProjects
                              join e in _dBContext.Employees on ep.EmpId equals e.Id
                              join p in _dBContext.Projects on ep.ProjectId equals p.Id
                              join role in _dBContext.Roles on ep.RoleId equals role.Id
                                    where e.Id == empId
                              select new { RoleName = role.RoleName, ProjectName= p.ProjectName, EmpId= ep.EmpId, ProjectId= ep.ProjectId, StartDate= ep.StartDate, EndDate= ep.EndDate, ReportingTo= ep.ReportingTo }).ToListAsync();

            if (result != null)
            {
                return APIUtility.BindResponse(result, true);

            }

            return APIUtility.BindResponse(null!, false);
        }
        public async Task<Response> PostProject(Project project)
        {
                await _dBContext.Projects.AddAsync(project);
              var result =  await _dBContext.SaveChangesAsync();
                if (result != 0)
                    return APIUtility.BindResponse(result, true);
                return APIUtility.BindResponse(result, false);
        }

        public async Task<Response> CreateEmployeeProject(EmployeeProject employeeProject)
        {
                await _dBContext.EmployeeProjects.AddAsync(employeeProject);
                var result = await _dBContext.SaveChangesAsync();
                if (result != 0)
                    return APIUtility.BindResponse(result, true);
                return APIUtility.BindResponse(result, false);
        }

        public async Task<Response> GetByProjectId(string EmpId)
        {
            var result = await _dBContext.EmployeeProjects.Where(x => x.EmpId == EmpId).ToListAsync();
            if (result != null)
            {
                return APIUtility.BindResponse(result, true);
            }
            {
                return APIUtility.BindResponse(null!, false);
            }

        }
    }
}
