using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly IEmployeeSkillsService _employeeSkills;
        public EmployeeSkillsController(IEmployeeSkillsService employeeSkills)
        {
            _employeeSkills = employeeSkills;
        }

        [HttpGet]
        [Route("GetEmployeeSkills")]
        public async Task<IActionResult> GetEmployeeSkills()
        {
            try
            {
                var result = await _employeeSkills.getEmployeeSkills();
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddEmployeeSkill")]
        public async Task<IActionResult> AddEmployeeSkill(EmployeeSkills employeeSkill)
        {
            try
            {
                var result = await _employeeSkills.SaveEmployeeSkills(employeeSkill);
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
