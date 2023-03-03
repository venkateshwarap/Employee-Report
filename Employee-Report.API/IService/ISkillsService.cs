using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface ISkillsService
    {
        Task<List<Skills>> GetSkills();
    }
}
