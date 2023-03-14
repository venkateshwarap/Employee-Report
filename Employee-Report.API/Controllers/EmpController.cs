using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private IEmpService _empService;
        private EmployeeInfoContext _dBContext;
        public EmpController(IEmpService empService, EmployeeInfoContext context)
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
                var emp =  _empService.GetEmployeeById(Id);

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
