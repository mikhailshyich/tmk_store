using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Repos;

namespace TMKStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart cartInterface;

        public CartController(ICart cartInterface)
        {
            this.cartInterface = cartInterface;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Cart>> AddProductAsync(Guid userId, Guid productID, int productCount)
        {
            var cartProduct = await cartInterface.AddCartProductAsync(userId, productID, productCount);
            return Ok(cartProduct);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Product>>> GetCartByIdUserAsync(Guid userId)
        {
            var cartUser = await cartInterface.GetCartByIdUserAsync(userId);
            return Ok(cartUser);
        }

        [HttpDelete("delete/{cartId}")]
        public async Task<ActionResult<List<Product>>> DeleteCartProductByIdAsync(Guid cartId)
        {
            var cartUser = await cartInterface.DeleteCartProductAsync(cartId);
            return Ok(cartUser);
        }

        [HttpPut("update/{cartId}")]
        public async Task<ActionResult<Cart>> DeleteCartProductByIdAsync(Guid cartId, int updateCount)
        {
            var cartUser = await cartInterface.UpdateCartRecordAsync(cartId, updateCount);
            return Ok(cartUser);
        }
    }
}
