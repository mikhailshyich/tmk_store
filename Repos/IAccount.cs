using TMKStore.DTOs;
using TMKStore.Models;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        LoginResponse RefreshToken(UserSession userSession);
        Task<ApplicationUser> GetUser(string email);
    }
}
