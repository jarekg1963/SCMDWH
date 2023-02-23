using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace SCMDWH.Client.AuthProviders
{
	public class AuthStateProvider : AuthenticationStateProvider
	{
		private readonly HttpClient _httpClient;
		private readonly ILocalStorageService _localStorage;
		private readonly AuthenticationState _anonymous;
		public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_localStorage = localStorage;
			_anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var token = await _localStorage.GetItemAsync<string>("SCMDWH");
			if (string.IsNullOrWhiteSpace(token))
				return _anonymous;
			var payload = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType");
			var datetime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payload.Claims.First(x => x.Type == "exp").Value));
			if (datetime.UtcDateTime <= DateTime.UtcNow)
			{
				NotifyUserLogout();
				return _anonymous;
			}
		
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
			return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
		}
        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
		{
			var authState = Task.FromResult(_anonymous);
			NotifyAuthenticationStateChanged(authState);
		}


		#region supportedfuntions

	


		public static class JwtParser
		{
			public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
			{
				var claims = new List<Claim>();
				var payload = jwt.Split('.')[1];

				var jsonBytes = ParseBase64WithoutPadding(payload);

				var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
				claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
				return claims;
			}
			private static byte[] ParseBase64WithoutPadding(string base64)
			{
				switch (base64.Length % 4)
				{
					case 2: base64 += "=="; break;
					case 3: base64 += "="; break;
				}
				return Convert.FromBase64String(base64);
			}
		}
		#endregion

	}
}
