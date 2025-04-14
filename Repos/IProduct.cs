using TMKStore.Models;

namespace TMKStore.Repos
{
    public interface IProduct
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Guid productId);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid productId);
    }
}
