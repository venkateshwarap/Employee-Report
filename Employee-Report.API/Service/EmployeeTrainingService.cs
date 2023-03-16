using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.Model.Models;

namespace Employee_Report.API.Service
{
    public class EmployeeTrainingService:IEmployeeTrainingService
    {

        private readonly EmployeeInfoContext _eatrackingContext;
        public EmployeeTrainingService(EmployeeInfoContext eatrackingContext)
        {
            _eatrackingContext = eatrackingContext;
        }

        public List<EmployeeTraining> GetEmployeeTraningDetails()
        {
            return _eatrackingContext.EmployeeTrainings.ToList();
        }

        public List<EmployeeTraining> GetEmployeeTraningDetailsById(string EmpID)
        {
            return _eatrackingContext.EmployeeTrainings.ToList().FindAll(x => x.EmpId == EmpID);
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
