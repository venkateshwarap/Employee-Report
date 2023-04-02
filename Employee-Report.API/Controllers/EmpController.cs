using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService _empService;
        public EmpController(IEmpService empService)
        {
            _empService = empService;
        }
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            try
            {
                var result = await _empService.GetEmployee();
                if (result.status)
                {
                    return Ok(result);
                }
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(string Id)
        {
            try
            {
                var result = await _empService.GetEmployeeById(Id);

                if (result.status)
                {
                    Ok(result);
                    
                }
                return NotFound(result);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
