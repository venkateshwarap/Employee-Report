using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmployeeSkillsService : IEmployeeSkillsService
    {
        private EmployeeInfoContext _context;

        public EmployeeSkillsService(EmployeeInfoContext context)
        {
            _context = context;
        }
        public async Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkills)
        {
            await _context.EmployeeSkills.AddAsync(employeeSkills);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return APIUtility.BindResponse(result, true, Constants.Response_Add_EmployeeSkills_Success);
            }
            {
                return APIUtility.BindResponse(result, false, Constants.Response_Add_EmployeeSkills_Failue);
            }
        }

        public async Task<Response> GetEmployeeSkills()
        {
            var employeeSkillsDetails = new List<EmployeeSkills_Skills_Entity>();
                var result = await (from empskills in _context.EmployeeSkills
                              join skills in _context.Skills on empskills.SkillId equals skills.Id
                              select new { EmpId = empskills.EmpId, SkillName = skills.SkillName }).ToListAsync();

                if (result != null)
                {
                    return APIUtility.BindResponse(result!, true);
                }

            return APIUtility.BindResponse(null!, false);
        }
        public async Task<Response> GetEmployeeSkillsByID(int id)
        {
            var result =await (from empskills in _context.EmployeeSkills
                          join skills in _context.Skills on empskills.Id equals skills.Id
                          where empskills.Id == id
                          select new { EmpId = empskills.EmpId, SkillName= skills.SkillName }).ToListAsync();
            if(result != null)
            {
                return APIUtility.BindResponse(result!, true);
            }
            return APIUtility.BindResponse(null!, false);
        }
        public async Task<Response> GetEmployeeSkillsByEmpId(string id)
        {
            
            var result = await (from empskills in _context.EmployeeSkills
                                join skills in _context.Skills on empskills.Id equals skills.Id
                                where empskills.EmpId == id
                                select new { EmpId = empskills.EmpId, SkillName = skills.SkillName }).ToListAsync();
            if (result != null)
            {
                return APIUtility.BindResponse(result!, true);
            }
            return APIUtility.BindResponse(null!, false);
        }
       
    }
}
