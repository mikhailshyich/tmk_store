using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Repos;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder orderInterface;

        public OrderController(IOrder orderInterface)
        {
            this.orderInterface = orderInterface;
        }

        [HttpPost("add")]
        public async Task<ActionResult<OrderResponse>> AddOrderAsync(Guid userId, decimal productPrice, Guid guidCarts)
        {
            var order = await orderInterface.AddOrderAsync(userId, productPrice, guidCarts);
            return Ok(order);
        }
    }
}
