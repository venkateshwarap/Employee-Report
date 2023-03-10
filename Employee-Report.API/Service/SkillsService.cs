using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class SkillsService: ISkillsService
    {
        private EatrackingContext _context;
        public SkillsService(EatrackingContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddSkill(Skill skill)
        {
            var doesSkillExist = await _context.Skills.Where(x => x.SkillName == skill.SkillName).FirstOrDefaultAsync();
            if (doesSkillExist == null)
            {
                await _context.Skills.AddAsync(skill);
                var result = _context.SaveChanges();
                return BindResponse(result, true, Constants.Response_Add_Skill_Success);
            }
            else
            {
                return BindResponse(doesSkillExist.SkillName, false, Constants.Response_Skill_Already_Exists);
            }
        }
        public async Task<List<Skill>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        private Response BindResponse(Object Obj = null!, bool Status = true, string Message = "")
        {
            Response resp = new Response();
            resp.response = Obj;
            resp.message = Message;
            resp.status = Status;
            return resp;
        }
    }
}
