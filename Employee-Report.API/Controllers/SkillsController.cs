using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
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
        private readonly ISkillsService _skillsService;
        public SkillsController(EatrackingContext eatrackingContext, ISkillsService skillsService)
        {
            _eatrackingContext = eatrackingContext;
            _skillsService = skillsService;
        }

        [HttpGet]
        [Route("GetSkills")]
        public string GetSkills()
        {
            var result = _eatrackingContext.Skills.ToList();
            if (result.Count != 0)
            {
                if (result.Count == 0)
                    return Constants.Response_Database_Empty;
                return String.Join(", ", result.Select(x => x.SkillName));
            }
            return Constants.Response_Database_Empty;
        }

        [HttpPost]
        [Route("AddSkill")]
        public async Task<IActionResult> AddSkill(Skills skill)
        {
            try
            {
                var result = await _skillsService.AddSkill(skill);
                if (result.Equals(0))
                {
                    return BadRequest();
                }
                else
                {
                    if (result.status)
                        return Ok(result);
                    return BadRequest(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
