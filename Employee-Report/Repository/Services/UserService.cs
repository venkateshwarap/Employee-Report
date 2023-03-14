using Employee.DataModel.Models;
using Employee_Report.Repository.IServices;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Employee_Report.Repository.Services
{
    public class UserService : IUserService
    {
        HttpClient _httpClient = new HttpClient();
        public UserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        private static string EncryptKey(string security)
        {
            var salt = "abcdefghijklmnopqrstuvwxyz";
            var md5 = new HMACMD5(Encoding.UTF8.GetBytes(salt + security));
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(security));
            return System.Convert.ToBase64String(data);
        }
        public async Task<HttpResponseMessage> Login(LoginModel model)
        {
            try
            {
               // model.security = EncryptKey(model.security);
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(AppSettings.Config.Login, stringContent);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
