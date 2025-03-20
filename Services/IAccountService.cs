using TMKStore.DTOs;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<LoginResponse> RefreshToken(UserSession userSession);
        Task<WeatherForecast[]> GetWeatherForecast();
    }
}
