using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Login(LoginModel model);
    }
}
