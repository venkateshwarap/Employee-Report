using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_ADMIN_LEARNING)]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILearningService _learningService;
        public LearningController(ILearningService learningService)
        {
            _learningService = learningService;
        }

        [HttpGet]
        [Route(Constants.GET)]
        public async Task<IActionResult> GetLearnings()
        {
            try
            {
                var result = await _learningService.GetLearnings();
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
        public async Task<IActionResult> AddNewLearning(Learning learning)
        {
            try
            {
                var result = await _learningService.AddNewLearning(learning);
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
