using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntelleactualPropertyController : ControllerBase
    {
        private readonly IIntelleactalProperty _intelleactal;
        public IntelleactualPropertyController(IIntelleactalProperty intelleactal)
        {
            _intelleactal = intelleactal;
        }

        [HttpPost]
        [Route("getById")]
        public async Task<IActionResult> GetById(string empid)
        {
            var result = await _intelleactal.GetById(empid);
            return Ok(result);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetALL()
        {
            var result = await _intelleactal.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(IntelleactualProperty intelleactal)
        {
            var result = await _intelleactal.Create(intelleactal);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(IntelleactualProperty intelleactal)
        {
            var result = await _intelleactal.Update(intelleactal);
            return Ok(result);
        }
    }
}
