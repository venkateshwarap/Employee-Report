using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface IEmployeeLearningService
    {
        public ResponseModel SaveEmployeeLearningDetails(EmployeeLearning learning);
        public List<EmployeeLearning> GetEmployeelearningDetails();
    }
}
