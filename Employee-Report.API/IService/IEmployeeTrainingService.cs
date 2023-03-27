using Employee.DataModel.Models;
using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface IEmployeeTrainingService
    {
        public ResponseModel SaveEmployeeTraningDetails(EmployeeTraining employeeTrainng);
        public List<EmployeeTraining> GetEmployeeTraningDetails();

        public Task<Response> GetEmployeeTraningDetailsById(string EmpID);
    }
}
