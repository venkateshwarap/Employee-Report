﻿using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EACouncil)]
    [ApiController]
    public class EACouncilController : ControllerBase
    {
        private readonly IEACouncilService _BenchService;
        public EACouncilController(IEACouncilService BenchService)
        {
            _BenchService = BenchService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBenchEntry(EACouncilEntryExit benchEntry)
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

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEACouncilDetails()
        {
            try
            {
                var result = await _BenchService.GetAllEACouncilEntryExit();
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
