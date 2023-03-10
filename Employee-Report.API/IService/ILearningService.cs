using Employee.DataModel.Models;
using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface ILearningService
    {
        public ResponseModel SaveLearningDetails(Learning learning);
        public List<Learning> GetlearningDetails();
    }
}
