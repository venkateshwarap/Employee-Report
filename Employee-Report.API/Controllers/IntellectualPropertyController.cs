using Employee_Report.API.Service;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_INTELLECTUAL_PROPERTY)]
    [ApiController]
    public class IntellectualPropertyController : ControllerBase
    {
        private readonly IIntelleactalProperty _intelleactal;
        public IntellectualPropertyController(IIntelleactalProperty intelleactal)
        {
            _intelleactal = intelleactal;
        }

        [HttpPost]
        [Route(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetById(string empid)
        {
            var result = await _intelleactal.GetById(empid);
            return Ok(result);
        }

        [HttpGet]
        [Route(Constants.GET)]
        public async Task<IActionResult> GetALL()
        {
            var result = await _intelleactal.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route(Constants.CREATE)]
        public async Task<IActionResult> Create(IntellectualProperty intelleactal)
        {
            var result = await _intelleactal.Create(intelleactal);
            return Ok(result);
        }

        [HttpPut]
        [Route(Constants.UPDATE)]
        public async Task<IActionResult> Update(IntellectualProperty intelleactal)
        {
            var result = await _intelleactal.Update(intelleactal);
            return Ok(result);
        }
    }
}
