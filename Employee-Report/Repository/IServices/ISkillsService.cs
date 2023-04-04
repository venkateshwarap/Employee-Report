using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface ISkillsService
    {
        Task<Response> GetSkills();
        Task<Response> AddSkill(Skill skill);
    }
}
