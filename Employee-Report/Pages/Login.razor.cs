using Employee.DataModel.Models;
using Employee_Report.Auth;

namespace Employee_Report.Pages
{
    public partial class Login
    {
        public LoginModel model = new LoginModel();

        HttpClient _httpClient = new HttpClient();
        Repository.Services.UserService service = new Repository.Services.UserService();
        private async Task Authenticate()
        {

            var result = await service.Login(model);

            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(new LoginModel
            {
                UserName = model.UserName

            });

            if (result.IsSuccessStatusCode)
            {
                navManager.NavigateTo("/employee", true);
            }
            else
            {
                //navManager.NavigateTo("/login");
                model.IsValidLogin = false;
            }
        }
    }
}
