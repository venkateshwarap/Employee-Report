using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Employee_Report.API.Service
{
    public class EmployeeLearningService : IEmployeeLearningService
    {

        private readonly EatrackingContext _context;
        public EmployeeLearningService(EatrackingContext context)
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
