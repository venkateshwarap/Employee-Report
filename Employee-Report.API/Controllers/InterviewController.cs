using Employee.DataModel.Models;
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
        [Route("GetAllInterviews")]
        public async Task<IActionResult> GetAllInterviews()
        {
            try
            {
                var result = await _interviewService.GetInterviews();
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
        [Route("GetInterviewByID")]
        public async Task<IActionResult> GetIntervieByID(int id)
        {
            try
            {
                var empByID = await _interviewService.GetInterviewByID(id);
                if(empByID != null)
                {
                    return Ok(empByID);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddInterview")]
        public async Task<IActionResult> AddInterview(Interview interview)
        {
            try
            {
                var result = await _interviewService.AddInterview(interview);
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
