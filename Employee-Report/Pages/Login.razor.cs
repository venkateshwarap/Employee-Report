using Employee_Report.Model.Models;
using Employee_Report.Auth;
using Microsoft.AspNetCore.Components;
using Employee_Report.Repository.IServices;

namespace Employee_Report.Pages
{
    public partial class Login
    {
        [Inject]
        IHttpContextAccessor _HttpContext { get; set; }

        [Inject]
        private IUserService _service { get; set; }
      
        public LoginModel model = new LoginModel();
        private async Task Authenticate()
        {

            var result = await _service.Login(model);

            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(new LoginModel
            {
                UserName = model.UserName

            });

            if (result.IsSuccessStatusCode)
            {
                _HttpContext.HttpContext.Session.Clear();
                navManager.NavigateTo("/employee", true);
            }
            else
            {
                model.IsValidLogin = false;
            }
        }
    }
}
