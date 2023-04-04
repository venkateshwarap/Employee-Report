using Employee_Report.Model.Models;
using employee_report.api.iservice;
using Microsoft.AspNetCore.Mvc;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EMPLOYEE_PROJECT)]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private IProjectService _projectService;
        public EmployeeProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet(Constants.GET)]
        public async Task<IActionResult> GetEmployeeProject()
        {
            try
            {
                var result = await _projectService.GetEmployeeProjectDetails();
                if (!result.status)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(Constants.CREATE)]
        public async Task<IActionResult> AddEmployeeProject(EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _projectService.CreateEmployeeProject(employeeProject);
                    if (result.status)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound(result);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return BadRequest();
        }

        [HttpGet(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetProjectByEmployeeId(string EmpId)
        {
            try
            {

                var  result = await _projectService.GetById(EmpId);

                if (!result.status)
                {
                    return NotFound(result);
                }


                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
