using Employee.DataModel.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Employee_Report.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // await Task.Delay(5000);
                var userSessionStorageResult = await _sessionStorage.GetAsync<LoginModel>("LoginModel");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null)

                    return await Task.FromResult(new AuthenticationState(_anonymous));
                var claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userSession.UserName)
                    }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsprincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }
        public async Task UpdateAuthenticationState(LoginModel loginModel)
        {
            ClaimsPrincipal claimsPrincipal;
            if (loginModel != null)
            {
                await _sessionStorage.SetAsync("LoginModel", loginModel);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginModel.UserName)
                    }, "CustomAuth"));

            }
            else
            {
                await _sessionStorage.DeleteAsync("LoginModel");
                claimsPrincipal = _anonymous;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

    }
}
