using Blazored.LocalStorage;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Providers;
using HRManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace HRManagement.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationService(IClient client, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authRequest = new AuthRequest()
                { Email = email, Password = password };

                var authResponse = await _client.LoginAsync(authRequest);

                if (authResponse.Token != string.Empty)
                {
                    await _localStorageService.SetItemAsync("token", authResponse.Token);
                    //set claims in blazor and login state 

                    await ((ApiAuthStateProvider)_authenticationStateProvider).LoggedIn();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task Logout()
        {

            //remove calims in Blazor and invalidate login state
            await ((ApiAuthStateProvider)_authenticationStateProvider).LoggedOut();

        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, UserName = userName, Password = password, Email = email };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
