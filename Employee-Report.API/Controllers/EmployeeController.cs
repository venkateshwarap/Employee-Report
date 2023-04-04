using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EMPLOYEE)]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpService _empService;
        public EmployeeController(IEmpService empService)
        {
            _empService = empService;
        }
        [HttpGet(Constants.GET)]
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

        [HttpGet(Constants.GET_BY_ID)]
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
