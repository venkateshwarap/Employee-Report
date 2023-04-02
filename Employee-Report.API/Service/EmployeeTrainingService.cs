using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
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

        public Response SaveEmployeeTraningDetails(EmployeeTraining employeeTrainng)
        {
           _eatrackingContext.EmployeeTrainings.Add(employeeTrainng);
           var result = _eatrackingContext.SaveChanges();
            if(result != 0)
            {
                return APIUtility.BindResponse(result, true, "Employee Traning has been added successfully!");
            }
            return APIUtility.BindResponse(result, false);

        }
    }
}
