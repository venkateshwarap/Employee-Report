using Employee_Report.Model.Models;
using employee_report.api.iservice;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            this._projectService = projectService;
        }
        [HttpGet("GetProject")]
        public async Task<IActionResult> GetProject()
        {
            try
            {
                var p = await _projectService.GetProjectDetails();

                if (p == null)
                {
                    return NotFound();
                }
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetEmployeeProject")]
        public async Task<IActionResult> GetEmployeeProject()
        {
            try
            {
                var p = await _projectService.GetEmployeeProjectDetails();
                if (p == null)
                {
                    return NotFound();
                }
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetEmployeeProjectById")]
        public async Task<IActionResult> GetEmployeePOCById(string empid)
        {
            try
            {
                var p = await _projectService.GetByProjectId(empid);
                if (p == null)
                {
                    return NotFound();
                }
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddEmployeeProject")]
        public async Task<IActionResult> AddEmployeeProject([FromBody] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = await _projectService.PostEmployeeProject(employeeProject);
                    if (p > 0)
                    {
                        return Ok(p);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpGet("GetProjectByEmployeeId")]
        public async Task<IActionResult> GetProjectByEmployeeId(string EmpId)
        {
            if (EmpId == null)
            {
                return BadRequest();
            }

            try
            {
                var p = _projectService.GetById(EmpId);

                if (p == null)
                {
                    return NotFound();
                }


                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = await _projectService.PostProject(project);
                    if (p > 0)
                    {
                        return Ok(p);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
