using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace DP_SUM0023.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage sessionStorage;
        private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorage = await sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorage.Success ? userSessionStorage.Value : null;
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var claims = new List<Claim>() { new Claim(ClaimTypes.Name, userSession.Username), new Claim(ClaimTypes.Role, userSession.Role) };
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async Task UpdateAuthenticationStateAsync(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                await sessionStorage.SetAsync("UserSession", userSession);

                var claims = new List<Claim>() { new Claim(ClaimTypes.Name, userSession.Username), new Claim(ClaimTypes.Role, userSession.Role)};
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            }
            else
            {
                await sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetAccountUsername()
        {
            var userSessionStorage = await sessionStorage.GetAsync<UserSession>("UserSession");
            var userSession = userSessionStorage.Success ? userSessionStorage.Value : null;
            if (userSession == null)
                return null;

            return userSession.Username;
        }
    }
}
