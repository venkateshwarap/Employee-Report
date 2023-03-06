using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {

        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        [HttpGet]
        [Route("GetEmployeeTraning")]
        public List<Training> GetTranings()
        {
            return _trainingService.GetTraningDetails();
        }
        [HttpPost]
        [Route("SaveEmployeeTraning")]
        public ResponseModel Save(Training training)
        {
            return _trainingService.SaveTraningDetails(training);
        }
    }
}
