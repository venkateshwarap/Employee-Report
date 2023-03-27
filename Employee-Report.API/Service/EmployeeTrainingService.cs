using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Response> GetEmployeeTraningDetailsById(string EmpID)
        {
            var res=  await _eatrackingContext.EmployeeTrainings.Where(x => x.EmpId == EmpID).ToListAsync();
            return APIUtility.BindResponse(res, true);
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
