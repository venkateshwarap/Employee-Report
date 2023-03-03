using Employee_Report.API.IService;
using Employee_Report.Model.Models;

namespace Employee_Report.API.Service
{
    public class SkillsService: ISkillsService
    {
        private EatrackingContext _dBContext;

        public SkillsService(EatrackingContext context)
        {
            this._dBContext = context;
        }

        public async Task<List<Skills>> GetSkills()
        {
            return _dBContext.Skills.ToList();
        }
    }
}
