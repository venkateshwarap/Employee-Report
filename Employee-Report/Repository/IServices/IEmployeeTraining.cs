using Employee.DataModel.Models;
namespace Employee_Report.Repository.IServices
   
{
    public class IEmployeeTraining
    {
        Task<IEnumerable<EmployeeTrainingEntity>> GetEmployeeTrainingDetails();
        Task<EmployeeTrainingEntity> GetEmployeeTrainingById(string Id);
        int AddEmployeeTrainingById(EmployeeTraining employeeTraining);
    }
}
