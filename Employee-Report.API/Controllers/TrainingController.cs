using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_ADMIN_TRAININGS)]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        [Route(Constants.GET)]
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

        [HttpGet]
        [Route(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetTrainingById(string Id)
        {
            try
            {
                var result = await _trainingService.GetTrainingById(Id);
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
        [Route(Constants.CREATE)]
        public async Task<IActionResult> AddNewTraining(Training training)
        {
            try
            {
                var result = await _trainingService.AddNewTraining(training);
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
