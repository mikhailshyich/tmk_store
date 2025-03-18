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

        [HttpPost("registration")]
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

        [HttpGet("goods")]
        public ActionResult<GoodsDTO[]> GetGoods()
        {
            var goods = new List<GoodsDTO>();
            var goods1 = new GoodsDTO("Моцарелла пицца", "2600");
            var goods2 = new GoodsDTO("Моцарелла пицца", "1000");
            var goods3 = new GoodsDTO("Моцарелла пицца", "500");
            var goods4 = new GoodsDTO("Моцарелла пицца", "250");
            goods.Add(goods1);
            goods.Add(goods2);
            goods.Add(goods3);
            goods.Add(goods4);
            return Ok(goods);
        }
    }
}
