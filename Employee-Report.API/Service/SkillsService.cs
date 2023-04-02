using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class SkillsService : ISkillsService
    {
        private EmployeeInfoContext _context;

        public SkillsService(EmployeeInfoContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddNewSkill(Skill skill)
        {
                await _context.Skills.AddAsync(skill);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return BindResponse(result, true, Constants.Response_Add_Skill_Success);
                }
                {
                    return BindResponse(result, true, Constants.Response_Add_Skill_Failure);
                }
        }

        public async Task<Response> GetSkills()
        {
            var result = await _context.Skills.ToListAsync();
            if (result.Count > 0)
                return BindResponse(result, true);
            return BindResponse(result, false);
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
