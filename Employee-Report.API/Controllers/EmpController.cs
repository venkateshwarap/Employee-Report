﻿using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.API.IService;
using Employee_Report.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private IEmpService _empService;
        private EatrackingContext _dBContext;
        public EmpController(IEmpService empService, EatrackingContext context)
        {
            this._empService = empService;
            this._dBContext = context;
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
