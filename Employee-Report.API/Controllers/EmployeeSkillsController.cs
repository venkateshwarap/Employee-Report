using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EMPLOYEE_SKILLS)]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly IEmployeeSkillsService _employeeSkillService;
        public EmployeeSkillsController(IEmployeeSkillsService employeeSkillService)
        {
            _employeeSkillService = employeeSkillService;
        }

        [HttpGet]
        [Route(Constants.GET)]
        public async Task<IActionResult> GetEmployeeSkill()
        {
            try
            {
                var empSkills = await _employeeSkillService.GetEmployeeSkills();
                if (!empSkills.status)
                {
                    return NotFound(empSkills);
                }
                return Ok(empSkills);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetEmployeeSkillsByID(int id)
        {
            try
            {
                var empSkillByID = await _employeeSkillService.GetEmployeeSkillsByID(id);
                if(empSkillByID.status)
                {
                    return Ok(empSkillByID);
                }
                return NotFound(); 
            }catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route(Constants.GET_BY_EMP_ID)]
        public async Task<IActionResult> GetEmployeeSkillsEmpId(string id)
        {
            try
            {
                var result = await _employeeSkillService.GetEmployeeSkillsByEmpId(id);
                if (result.status)
                {
                    return Ok(result);
                }
                return NotFound(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route(Constants.CREATE)]
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
