using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/Trainings")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        [Route(Constants.get)]
        public async Task<IActionResult> GetTrainings()
        {
            try
            {
                var result = await _trainingService.GetTrainings();
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
        [Route(Constants.create)]
        public async Task<IActionResult> AddNewTraining(Training training)
        {
            try
            {
                var result = await _trainingService.AddNewTraining(training);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
