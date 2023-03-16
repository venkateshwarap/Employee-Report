using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Service
{
    public class EmployeeSkillsService : IEmployeeSkillsService
    {
        private EmployeeInfoContext _context;

        public EmployeeSkillsService(EmployeeInfoContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkills)
        {
            await _context.EmployeeSkills.AddAsync(employeeSkills);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Add_EmployeeSkills_Success);
            }
            {
                return BindResponse(result, false, Constants.Response_Add_EmployeeSkills_Failue);
            }
        }

        public async Task<List<EmployeeSkills_Skills_Entity>> GetEmployeeSkills()
        {
            var employeeSkillsDetails = new List<EmployeeSkills_Skills_Entity>();
            if (_context != null)
            {
                var result = (from empskills in _context.EmployeeSkills
                              join skills in _context.Skills on empskills.SkillId equals skills.Id
                              select new { empskills.EmpId, skills.SkillName}).ToList();

                if (result != null)
                {
                    foreach (var res in result)
                    {
                        employeeSkillsDetails.Add(new EmployeeSkills_Skills_Entity
                        {
                            EmpID = res.EmpId,
                            SkillName = res.SkillName,
                        });
                    }
                }
            }
            return employeeSkillsDetails;
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
