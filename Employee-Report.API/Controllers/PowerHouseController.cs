using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_POWER_HOUSE)]
    [ApiController]
    public class PowerHouseController : ControllerBase
    {
        private readonly IPowerHouseService _BenchService;
        public PowerHouseController(IPowerHouseService BenchService)
        {
            _BenchService = BenchService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBenchEntry(PowerHouse benchEntry)
        {
            try
            {
                var result = await _BenchService.CreateCouncilEntry(benchEntry);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("createPowerHouse_Roles")]
        public async Task<IActionResult> CreatePowerhouse_Role(PowerHouse_Role powerHouse_Role)
        {
            try
            {
                var result = await _BenchService.CreateCouncilEntry(powerHouse_Role);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEACouncilDetails()
        {
            try
            {
                var result = await _BenchService.GetAllEACouncilEntryExit();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("getbyId")]
        public async Task<IActionResult> GetEACouncilDetailsById(string empid)
        {
            try
            {
                var result = await _BenchService.GetEACouncilByEmpId(empid);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEmployeeFromEACouncil(string empid)
        {
            try
            {
                var result = await _BenchService.DeleteFromEACouncil(empid);
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
