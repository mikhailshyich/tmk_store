using Microsoft.EntityFrameworkCore;
using TMKStore.Data;
using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Responses;
using TMKStore.States;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient;

        public AccountService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private const string BaseUrl = "api/account";

        public static bool CheckIfUnauthorized(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return true;
            }
            else { return false; }
        }

        private void GetProtectedClient()
        {
            if (Constants.JWTToken == "") return;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constants.JWTToken);
        }

        private async Task GetRefreshToken()
        {
            var response = await httpClient.PatchAsJsonAsync($"{BaseUrl}/refresh-token", new UserSession() { JWTToken = Constants.JWTToken });
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            Constants.JWTToken = result!.JWTToken;
        }

        public async Task<CustomResponses.LoginResponse> LoginAsync(LoginDTO model)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/login", model);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }

        public async Task<CustomResponses.RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/registration", model);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
            return result!;
        }

        public async Task<WeatherForecast[]> GetWeatherForecast()
        {
            GetProtectedClient();
            var response = await httpClient.GetAsync($"{BaseUrl}/weather");
            bool check = CheckIfUnauthorized(response);
            if (check)
            {
                await GetRefreshToken();
                return await GetWeatherForecast();
            }
            return await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
        }

        public async Task<LoginResponse> RefreshToken(UserSession userSession)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/refresh-token", userSession);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }
    }
}
