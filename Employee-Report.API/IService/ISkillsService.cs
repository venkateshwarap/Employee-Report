using Employee_Report.Model.Models;
using Employee_Report.Model;
using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface ISkillsService
    {
        Task<Response> GetSkills();
        Task<Response> AddNewSkill(Skill skill);
    }
}
