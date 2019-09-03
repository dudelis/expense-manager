using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseManager.Client
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public ServerAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var userInfo = await _httpClient.GetJsonAsync<string>("user");

            //var identity = suserInfo 
            //    ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userInfo.Name) }, "serverauth")
            //    : new ClaimsIdentity();
            var identity = new ClaimsIdentity();
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
