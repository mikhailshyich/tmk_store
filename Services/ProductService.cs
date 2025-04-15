using TMKStore.Models;
using TMKStore.Repos;

namespace TMKStore.Services
{
    public class ProductService : IProduct
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private const string BaseUrl = "api/product";


        public async Task<Product> AddProductAsync(Product model)
        {
            var product = await httpClient.PostAsJsonAsync($"{BaseUrl}/add", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> DeleteProductAsync(Guid productId)
        {
            var product = await httpClient.GetAsync($"{BaseUrl}/product-delete/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await httpClient.GetAsync($"{BaseUrl}/all");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response!;
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            var product = await httpClient.GetAsync($"{BaseUrl}/single-product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var product = await httpClient.PutAsJsonAsync($"{BaseUrl}/product-update", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }
    }
}
