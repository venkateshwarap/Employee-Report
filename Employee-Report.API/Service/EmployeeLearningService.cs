using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmployeeLearningService : IEmployeeLearningService
    {

        private readonly EmployeeInfoContext _context;
        public EmployeeLearningService(EmployeeInfoContext context)
        {
            this._context = context;
        }
        public List<EmployeeLearning> GetEmployeelearningDetails()
        {

            try
            {
                return _context.EmployeeLearnings.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Response GetEmployeelearningDetailsbyEmpID(string empId)
        {

            try
            {
                var result = _context.EmployeeLearnings.Where(x => x.EmpId == empId).FirstOrDefault();
                var res_result = _context.Learnings.Where(x=>x.Id==result!.Id).ToList();
                if (res_result.Count > 0)
                {
                  return  APIUtility.BindResponse(res_result, true);
                }
                return APIUtility.BindResponse(res_result, false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseModel SaveEmployeeLearningDetails(EmployeeLearning learning)
        {
            _context.Add(learning);
            _context.SaveChanges();
            return new ResponseModel()
            {
                Message = "Employee Learning Details in inserted successfully",
                Status = true
            };
        }

    }
}
