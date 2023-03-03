using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POCController : ControllerBase
    {
        private IPOCService _pocService;
        public POCController(IPOCService pocService)
        {
            this._pocService = pocService;
        }
        [HttpGet("GetPOC")]
        public async Task<IActionResult> GetPOC()
        {
            try
            {
                var p = await _pocService.GetPOCDetails();
                if (p == null)
                {
                    return NotFound();
                }
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetEmployeePOC")]
        public async Task<IActionResult> GetEmployeePOC()
        {
            try
            {
                var p = await _pocService.GetEmployeePOCDetails();
                if (p == null)
                {
                    return NotFound();
                }
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddPOC")]
        public async Task<IActionResult> AddPOC([FromBody] Poc poc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = await _pocService.PostPoc(poc);
                    if (p > 0)
                    {
                        return Ok(p);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost("AddEmployeePoc")]
        public async Task<IActionResult> AddEmployeePoc([FromBody] EmployeePoc employeePoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = await _pocService.PostEmployeePoc(employeePoc);
                    if (p > 0)
                    {
                        return Ok(p);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}
