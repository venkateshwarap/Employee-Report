using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EMPLOYEE_LEARNING)]
    [ApiController]
    public class EmployeeLearningController : ControllerBase
    {

        private readonly IEmployeeLearningService _employeeLearningService;
        public EmployeeLearningController(IEmployeeLearningService employeeLearningService)
        {
            _employeeLearningService = employeeLearningService;
        }

        [HttpGet(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetAllEmployeeLearningDetails(string empID)
        {
            var result =  await _employeeLearningService.GetEmployeeLearningbyEmpId(empID);
            if(result.status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route(Constants.CREATE)]
        public async Task<IActionResult> CreateEmployeeLearning(EmployeeLearning employee)
        {
            var result = await _employeeLearningService.CreateEmployeeLearning(employee);
            if(result.status)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet(Constants.GET)]
        public IActionResult GetAllEmployeeLearningDetails()
        {
            var result = _employeeLearningService.GetEmployeelearningDetails();
           return Ok(result);
        }



    }
}
