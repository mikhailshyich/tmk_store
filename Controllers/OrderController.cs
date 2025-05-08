using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMKStore.Components.Pages;
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
        public async Task<ActionResult<OrderResponse>> AddOrderAsync(Guid userId, decimal productPrice, int productCount, Guid productId, Guid uniqueGuid)
        {
            var order = await orderInterface.AddOrderAsync(userId, productPrice, productCount, productId, uniqueGuid);
            return Ok(order);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OrderResponse>> GetOrdersUserByIdAsync(Guid userId)
        {
            var order = await orderInterface.GetOrdersUserByIdAsync(userId);
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await orderInterface.GetOrderByIdAsync(id);
            return Ok(order);
        }
    }
}
