using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class InterviewService : IInterviewService
    {
        private EmployeeInfoContext _context;

        public InterviewService(EmployeeInfoContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddInterview(Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Add_Interview_Success);
            }
            {
                return BindResponse(result, false, Constants.Response_Add_Interview_Failure);
            }
        }

        public async Task<Response> GetInterviews()
        {
            var result = await _context.Interviews.ToListAsync();
            if (result.Count > 0)
                return BindResponse(result, true);
            return BindResponse(result, false);
        }

        public async Task<Response> GetInterviewByID(int id)
        {
            if (id != 0)
            {
                var result = await _context.Interviews.FindAsync(id);
                if (result == null)
                {
                    return BindResponse(result, false, "Data of selected Interview is not found");
                }
                return BindResponse(result, true, "Data of Interview with ID:" + id + " found");
            }
            else { return null; }
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
