using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class LearningService : ILearningService
    {
        private EmployeeInfoContext _context;

        public LearningService(EmployeeInfoContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddNewLearning(Learning learning)
        {
            await _context.Learnings.AddAsync(learning);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Add_Learning_Success);
            }
            {
                return BindResponse(result, true, Constants.Response_Add_Learning_Failure);
            }
        }

        public async Task<Response> GetLearnings()
        {
            var result = await _context.Learnings.ToListAsync();
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
