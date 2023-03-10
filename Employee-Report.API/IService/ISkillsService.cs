using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface ISkillsService
    {
        Task<List<Skill>> GetSkills();
        Task<Response> AddSkill(Skill skill);
    }
}
