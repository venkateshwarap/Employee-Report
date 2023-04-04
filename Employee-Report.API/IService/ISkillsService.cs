using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface ISkillsService
    {
        Task<Response> GetSkills();
        Task<Response> AddNewSkill(Skill skill);
    }
}
