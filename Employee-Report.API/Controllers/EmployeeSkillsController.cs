using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Service;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly IEmployeeSkillsService _employeeSkillService;
        public EmployeeSkillsController(IEmployeeSkillsService employeeSkillService)
        {
            _employeeSkillService = employeeSkillService;
        }

        [HttpGet]
        [Route(Constants.get)]
        public async Task<IActionResult> GetEmployeeSkill()
        {
            try
            {
                var empSkills = await _employeeSkillService.GetEmployeeSkills();
                if (empSkills == null)
                {
                    return NotFound();
                }
                return Ok(empSkills);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route(Constants.create)]
        public async Task<IActionResult> AddEmployeeSkill([FromBody] EmployeeSkills employeeSkills)
        {
            try
            {
                var result = await _employeeSkillService.AddEmployeeSkill(employeeSkills);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
