using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface IEmployeeTrainingService
    {
        Task<Response> SaveEmployeeTraningDetails(EmployeeTraining employeeTrainng);
        Task<Response> GetEmployeeTraningDetails();
        Task<Response> GetEmployeeTraningDetailsById(string EmpID);
    }
}
