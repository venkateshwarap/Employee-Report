using Employee_Report.API.IService;
using Employee_Report.Model.Models;

namespace Employee_Report.API.Service
{
    public class LearningService:ILearningService
    {
        private readonly EatrackingContext _context;
        public LearningService(EatrackingContext context)
        {
            _context = context;
        }

        public List<Learning> GetlearningDetails()
        {
            try
            {
               return _context.Learnings.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public ResponseModel SaveLearningDetails(Learning learning)
        {
            try
            {
                var response = _context.Add(learning);
                _context.SaveChanges();
                return new ResponseModel()
                {
                    Message = "Learning Details Inserted Successfully",
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = "Learning Details not inserted due to " + ex.Message,
                    Status = false
                };

            }


        }
    }
}
