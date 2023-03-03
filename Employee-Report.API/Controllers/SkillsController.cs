using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private EatrackingContext _eatrackingContext;
        public SkillsController(EatrackingContext eatrackingContext)
        {
            _eatrackingContext = eatrackingContext;
        }
        [HttpGet]
        [Route("GetSkills")]
        public string GetSkills()
        {
            var result = _eatrackingContext.Skills.ToList();
            return String.Join(", ", result.Select(x => x.SkillName));
        }
    }
}
