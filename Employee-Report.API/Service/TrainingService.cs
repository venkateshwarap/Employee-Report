using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class TrainingService : ITrainingService
    {
        private EmployeeInfoContext _context;

        public TrainingService(EmployeeInfoContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddNewTraining(Training training)
        {
            await _context.Training.AddAsync(training);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Add_Training_Success);
            }
            {
                return BindResponse(result, true, Constants.Response_Add_Training_Failure);
            }
        }

        public async Task<Response> GetTrainings()
        {
            var result = await _context.Training.ToListAsync();
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
