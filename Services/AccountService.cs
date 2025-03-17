using TMKStore.DTOs;
using TMKStore.Responses;
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

        public async Task<GoodsDTO[]> GetGoodsAsync(GoodsDTO model) =>
            await httpClient.GetFromJsonAsync<GoodsDTO[]>($"{BaseUrl}/goods");

        public async Task<CustomResponses.LoginResponse> LoginAsync(LoginDTO model)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/login", model);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }

        public async Task<CustomResponses.RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/register", model);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
            return result!;
        }
    }
}
