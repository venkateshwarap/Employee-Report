using Employee_Report.API.IService;
using Employee_Report.Model.Models;

namespace Employee_Report.API.Service
{
    public class EmployeeTrainingService:IEmployeeTrainingService
    {

        private readonly EatrackingContext _eatrackingContext;
        public EmployeeTrainingService(EatrackingContext eatrackingContext)
        {
            _eatrackingContext = eatrackingContext;
        }

        public List<EmployeeTraining> GetEmployeeTraningDetails()
        {
            return _eatrackingContext.EmployeeTrainings.ToList();
        }

        public ResponseModel SaveEmployeeTraningDetails(EmployeeTraining employeeTrainng)
        {
            _eatrackingContext.Add(employeeTrainng);
            _eatrackingContext.SaveChanges();
            return new ResponseModel()
            {
                Message = "Employee Traning details inserted successfully!",
                Status = true
            };
        }
    }
}
