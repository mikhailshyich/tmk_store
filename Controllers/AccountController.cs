using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await accountRepo.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await accountRepo.LoginAsync(model);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public ActionResult<LoginResponse> RefreshToken(UserSession model)
        {
            var result = accountRepo.RefreshToken(model);
            return Ok(result);
        }

        [HttpGet("weather")]
        [Authorize(Roles = "Admin")]
        public ActionResult<WeatherForecast[]> GetWeatherForecast()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray());
        }
    }
}
