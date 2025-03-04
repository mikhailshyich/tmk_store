using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TMKStore.DTOs;
using TMKStore.Repos;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount accountRepo;
        public AccountController(IAccount accountRepo) 
        {
            this.accountRepo = accountRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await accountRepo.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await accountRepo.LoginAsync(model);
            return Ok(result);
        }
    }
}
