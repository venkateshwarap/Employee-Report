using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_ADMIN_SKILLS)]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;
        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet]
        [Route(Constants.GET)]
        public async Task<IActionResult> GetSkills()
        {
            try
            {
                var result = await _skillsService.GetSkills();
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
        public async Task<IActionResult> AddNewSkill(Skill skill)
        {
            try
            {
                var result = await _skillsService.AddNewSkill(skill);
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
