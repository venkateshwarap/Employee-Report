using Employee_Report.API.IService;
using Employee_Report.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private IEmpService _empService;
        public EmpController(IEmpService empService)
        {
            this._empService = empService;
        }
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            try
            {
                var e = await _empService.GetEmployee();
                if (e == null)
                {
                    return NotFound();
                }
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var emp = await _empService.GetEmployeeById(Id);

                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
