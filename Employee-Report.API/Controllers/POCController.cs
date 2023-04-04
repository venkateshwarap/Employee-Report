using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_ADMIN_POC)]
    [ApiController]
    public class POCController : ControllerBase
    {
        private readonly IPOCService _pocService;
        public POCController(IPOCService pocService)
        {
            _pocService = pocService;
        }
        [HttpGet(Constants.GET)]
        public async Task<IActionResult> GetPOC()
        {
            try
            {
                var result = await _pocService.GetPOCDetails();
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
        

        [HttpPost(Constants.CREATE)]
        public async Task<IActionResult> AddPOC(Poc poc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _pocService.PostPoc(poc);
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
            return BadRequest();
        }

    }
}
