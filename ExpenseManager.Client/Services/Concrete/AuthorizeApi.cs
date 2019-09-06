using ExpenseManager.Client.Services.Interfaces;
using ExpenseManager.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseManager.Client.Services.Concrete
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Login(LoginModel model)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/authorize/login", stringContent);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }
        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/authorize/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task<UserInfoModel> GetUserInfo()
        {
            var result = await _httpClient.GetJsonAsync<UserInfoModel>("api/authorize/userinfo");
            return result;
        }
        public async Task Register(RegisterModel model)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/authorize/register", stringContent);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }
    }
}
