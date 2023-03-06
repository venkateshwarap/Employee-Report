using Employee_Report.API.IService;
using Employee_Report.Model.Models;

namespace Employee_Report.API.Service
{
    public class TrainingService:ITrainingService
    {
        private readonly EatrackingContext _eatrackingContext;
        public TrainingService(EatrackingContext eatrackingContext)
        {
            _eatrackingContext = eatrackingContext;
        }
        public List<Training> GetTraningDetails()
        {
            try
            {
                return _eatrackingContext.Trainings.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public ResponseModel SaveTraningDetails(Training traning)
        {
            try
            {
                _eatrackingContext.Add(traning);
                _eatrackingContext.SaveChanges();
                return new ResponseModel()
                {
                    Message = "Traning details is inserted successfully",
                    Status = true
                };
            }
            catch (Exception ex)
            {

                return new ResponseModel()
                {
                    Message = "Traning details does not inserted successfully " + ex.Message,
                    Status = false
                };
            }


        }
    }
}
