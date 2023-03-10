using Employee.DataModel.Models;
using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface ITrainingService
    {
        public ResponseModel SaveTraningDetails(Training traning);
        public List<Training> GetTraningDetails();
    }
}
