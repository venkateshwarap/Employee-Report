using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTrainingController : ControllerBase
    {

        private readonly IEmployeeTrainingService _employeeTrainingService;

        public EmployeeTrainingController(IEmployeeTrainingService employeeTrainingService)
        {
            _employeeTrainingService = employeeTrainingService;
        }
        [HttpGet("GetDetails")]
        public List<EmployeeTraining> GetEmployeeTraningDetails()
        {
            return _employeeTrainingService.GetEmployeeTraningDetails();
        }
        [HttpPost]
        public IActionResult SaveEmployeeTraning(EmployeeTraining employeeTraining)
        {
            return Ok(_employeeTrainingService.SaveEmployeeTraningDetails(employeeTraining));
        }

        [HttpGet("GetDetailsbyId")]
        public async Task<IActionResult> GetEmployeeTraningDetailsById(string empId)
        {
            var result = await _employeeTrainingService.GetEmployeeTraningDetailsById(empId);
            return Ok(result);
        }
    }
}
