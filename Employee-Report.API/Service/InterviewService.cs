using Employee_Report.API.IService;
using Employee_Report.Model;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class InterviewService: IInterviewService
    {
        private EatrackingContext _dBContext;

        public InterviewService(EatrackingContext context)
        {
            this._dBContext = context;
        }

        public ResponseModel AddInterviews(Interview interview)
        {
            try
            {
                _dBContext.Add(interview);
                _dBContext.SaveChanges();

                return new ResponseModel()
                {
                    Message = "Successfully Inserted new data",
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = "Failed to insert with the reson: " + ex.Message,
                    Status = false
                };
            }
        }

        public async Task<List<Interview>> GetInterviewDeatils()
        {
            return await _dBContext.Interviews.ToListAsync();
        }
    }
}
