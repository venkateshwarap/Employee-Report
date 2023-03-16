using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
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
        public ResponseModel SaveEmployeeTraning(EmployeeTraining employeeTraining)
        {
            return _employeeTrainingService.SaveEmployeeTraningDetails(employeeTraining);
        }

        [HttpGet("GetDetailsbyId")]
        public List<EmployeeTraining> GetEmployeeTraningDetailsById(string empId)
        {
            return _employeeTrainingService.GetEmployeeTraningDetailsById(empId);
        }
    }
}
