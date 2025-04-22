using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Repos;

namespace TMKStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productInterface;

        public ProductController(IProduct productInterface)
        {
            this.productInterface = productInterface;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> GetAllProductAsync()
        {
            var products = await productInterface.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("single-product/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> GetSingleProductAsync(Guid id)
        {
            var product = await productInterface.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Product>>> AddProductAsync(ProductDTO model)
        {
            var product = await productInterface.AddProductAsync(model);
            return Ok(product);
        }

        [HttpPut("product-update")]
        public async Task<ActionResult<List<Product>>> UpdateProductAsync(Product model)
        {
            var product = await productInterface.UpdateProductAsync(model);
            return Ok(product);
        }

        [HttpDelete("product-delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Product>>> DeleteProductAsync(Guid id)
        {
            var product = await productInterface.DeleteProductAsync(id);
            return Ok(product);
        }
    }
}
