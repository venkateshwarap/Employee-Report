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

        public async Task<Response> GetEmployeeTraningDetails()
        {
            var result = await _eatrackingContext.EmployeeTrainings.ToListAsync();
            if(result.Count > 0)
            {
            return APIUtility.BindResponse(result,true);
            }
            return APIUtility.BindResponse(result, false);

        }

        public async Task<Response> GetEmployeeTraningDetailsById(string EmpID)
        {
            var result =  await _eatrackingContext.EmployeeTrainings.Where(x => x.EmpId == EmpID).ToListAsync();
            if (result.Count > 0)
            {
                return APIUtility.BindResponse(result, true);
            }
            return APIUtility.BindResponse(result, false);
        }

        public async Task<Response> SaveEmployeeTraningDetails(EmployeeTraining employeeTrainng)
        {
          await _eatrackingContext.EmployeeTrainings.AddAsync(employeeTrainng);
           var result = await _eatrackingContext.SaveChangesAsync();
            if(result != 0)
            {
                return APIUtility.BindResponse(result, true, "Employee Traning has been added successfully!");
            }
            return APIUtility.BindResponse(result, false);

        }
    }
}
