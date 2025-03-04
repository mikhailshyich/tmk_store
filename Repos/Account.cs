using TMKStore.Data;
using TMKStore.DTOs;
using TMKStore.Responses;

namespace TMKStore.Repos
{
    public class Account : IAccount
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration config;

        public Account(AppDbContext appDbContext, IConfiguration config)
        {
            this.appDbContext = appDbContext;
            this.config = config;
        }

        public Task<CustomResponses.LoginResponse> LoginAsync(LoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponses.RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
