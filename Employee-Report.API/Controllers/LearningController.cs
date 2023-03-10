using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILearningService _learningService;
        public LearningController(ILearningService learningService)
        {
            _learningService = learningService;
        }
        [HttpGet]
        public List<Learning> GetLearnings()
        {
            return _learningService.GetlearningDetails();
        }
        [HttpPost]
        [Route("SaveLearningDetails")]
        public ResponseModel Save(Learning learning)
        {
            return _learningService.SaveLearningDetails(learning);
        }
    }
}
