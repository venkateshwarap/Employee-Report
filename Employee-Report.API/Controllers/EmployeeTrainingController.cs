using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_EMPLOYEE_TRAINING)]
    [ApiController]
    public class EmployeeTrainingController : ControllerBase
    {

        private readonly IEmployeeTrainingService _employeeTrainingService;

        public EmployeeTrainingController(IEmployeeTrainingService employeeTrainingService)
        {
            _employeeTrainingService = employeeTrainingService;
        }
        [HttpGet(Constants.GET)]
        public async Task<IActionResult> GetEmployeeTraningDetails()
        {
            var result = await _employeeTrainingService.GetEmployeeTraningDetails();
            if(result.status)
            return Ok(result);
            return NotFound(result);
        }
        [HttpPost(Constants.CREATE)]
        public async Task<IActionResult> SaveEmployeeTraning(EmployeeTraining employeeTraining)
        {
            var result = await _employeeTrainingService.SaveEmployeeTraningDetails(employeeTraining);
            if (result.status)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetEmployeeTraningDetailsById(string empId)
        {
            var result = await _employeeTrainingService.GetEmployeeTraningDetailsById(empId);
            if (result.status)
                return Ok(result);
            return NotFound(result);
        }
    }
}
