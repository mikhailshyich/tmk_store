using TMKStore.DTOs;
using TMKStore.Models;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public interface IProduct
    {
        Task<ProductResponse> AddProductAsync(ProductDTO product);
        Task<Product> UpdateProductAsync(Product product);
        Task<ProductResponse> DeleteProductAsync(Guid productId);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid productId);
    }
}
