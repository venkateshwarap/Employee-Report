using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmployeeSkillsService : IEmployeeSkillsService
    {
        private EatrackingContext _context;

        public EmployeeSkillsService(EatrackingContext context)
        {
            this._context = context;
        }
        public async Task<Response> SaveEmployeeSkills(EmployeeSkills employeeSkills)
        {
            await _context.EmployeeSkills.AddAsync(employeeSkills);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Add_EmployeeSkills_Success);
            }
            {
                return BindResponse(result, false, Constants.Response_Add_Interview_Failure);
            }
        }

        public async Task<Response> getEmployeeSkills()
        {
            var result = await _context.EmployeeSkills.ToListAsync();
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
