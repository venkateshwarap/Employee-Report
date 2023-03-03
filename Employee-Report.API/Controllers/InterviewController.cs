using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpGet]
        [Route("GetInterviews")]
        public async Task<IActionResult> GetInterviews()
        {
            try
            {
                var interview = await _interviewService.GetInterviewDeatils();
                if (interview == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(interview);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddInterview")]
        public IActionResult AddInterview([FromBody] Interview interview)
        {
            try
            {
                var newInterview = _interviewService.AddInterviews(interview);
                if (newInterview == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(newInterview);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
