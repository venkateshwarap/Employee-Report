using Employee.DataModel.Models;

namespace Employee_Report.Repository.IServices
{
    public class IEmployeeLearning
    {
        Task<IEnumerable<EmployeeLearningEntity>> GetEmployeeLearning();
        Task<IEnumerable<EmployeeLearningEntity>> GetEmployeeLearningbyEmpID();
         int AddEmployeeLearning(EmployeeLearning employeeLearning);
    }
}
