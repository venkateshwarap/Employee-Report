﻿using Employee_Report.Model.Models;
using employee_report.api.iservice;
using Microsoft.AspNetCore.Mvc;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_PROJECT)]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet(Constants.GET)]
        public async Task<IActionResult> GetProject()
        {
            try
            {
                var result = await _projectService.GetProjectDetails();

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

        [HttpPost(Constants.CREATE)]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
                try
                {
                    var result = await _projectService.PostProject(project);
                    if (result.status)
                    {
                        return Ok(result);
                    }
                      return BadRequest(result);
                }
                catch (Exception)
                {
                    throw;
                }
        }
    }
}
