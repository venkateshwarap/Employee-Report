using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/EmployeeLearning")]
    [ApiController]
    public class EmployeeLearningController : ControllerBase
    {

        private readonly IEmployeeLearningService _employeeLearningService;
        public EmployeeLearningController(IEmployeeLearningService employeeLearningService)
        {
            _employeeLearningService = employeeLearningService;
        }

        [HttpGet(Constants.getById)]
        public Response GetAllEmployeeLearningDetails(string empID)
        {
            return _employeeLearningService.GetEmployeelearningDetailsbyEmpID(empID);
        }
        [HttpPost]
        [Route(Constants.create)]
        public ResponseModel SaveEmployeeLearningDetails(EmployeeLearning employee)
        {
            return _employeeLearningService.SaveEmployeeLearningDetails(employee);
        }

        [HttpGet(Constants.get)]
        public List<EmployeeLearning> GetAllEmployeeLearningDetails()
        {
            return _employeeLearningService.GetEmployeelearningDetails();
        }



    }
}
