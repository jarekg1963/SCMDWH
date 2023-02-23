using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SCMDWH.Client.AuthProviders;
using SCMDWH.Shared.DTO;
using SCMDWH.Shared.Models;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SCMDWH.Client.Services
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private NavigationManager _navigationManager;
      

        public AuthenticationService
            (
                HttpClient client, 
                AuthenticationStateProvider authStateProvider, 
                ILocalStorageService localStorage, 
                NavigationManager navigationManager
            )
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }


        public async Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication)
        {
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var authResult = await _client.PostAsync("api/accounts/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, _options);
            if (!result.IsAuthSuccessful)
                return result;
             
            await _localStorage.SetItemAsync("SCMDWH", result.Token);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Token);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthResponseDto { IsAuthSuccessful = true };


        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("SCMDWH");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
            _navigationManager.NavigateTo("/login");
        }
    }

}
