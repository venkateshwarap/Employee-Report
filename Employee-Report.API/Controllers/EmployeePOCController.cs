using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EMPLOYEE_POC)]
    [ApiController]
    public class EmployeePOCController : ControllerBase
    {
        private readonly IPOCService _pocService;
        public EmployeePOCController(IPOCService pocService)
        {
            _pocService = pocService;
        }

        [HttpGet(Constants.GET)]
        public async Task<IActionResult> GetEmployeePOC()
        {
            try
            {
                var result = await _pocService.GetEmployeePOCDetails();
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
        public async Task<IActionResult> AddEmployeePoc(EmployeePoc employeePoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _pocService.PostEmployeePoc(employeePoc);
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
            return BadRequest();
        }

        [HttpGet]
        [Route(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetPOCByEmployeeId(string EmpId)
        {
            try
            {
                var result = await _pocService.GetById(EmpId);

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

    }
}
