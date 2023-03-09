using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface ISkillsService
    {
        Task<string> GetSkills();
        Task<Response> AddSkill(Skills skill);
    }
}
