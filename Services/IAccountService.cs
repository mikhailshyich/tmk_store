using TMKStore.DTOs;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<GoodsDTO[]> GetGoodsAsync(GoodsDTO model);
    }
}
