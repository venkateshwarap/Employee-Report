using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/Learnings")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILearningService _learningService;
        public LearningController(ILearningService learningService)
        {
            _learningService = learningService;
        }

        [HttpGet]
        [Route(Constants.get)]
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
        [Route(Constants.create)]
        public async Task<IActionResult> AddNewLearning(Learning learning)
        {
            try
            {
                var result = await _learningService.AddNewLearning(learning);
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
