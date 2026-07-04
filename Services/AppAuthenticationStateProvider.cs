using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace PlateE_learning.Services;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public void SignIn(ClaimsPrincipal principal)
    {
        _currentUser = principal;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void SignOut()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
