using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Repos;
using static TMKStore.Responses.CustomResponses;

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


        public async Task<ProductResponse> AddProductAsync(ProductDTO model)
        {
            var product = await httpClient.PostAsJsonAsync($"{BaseUrl}/add", model);
            var response = await product.Content.ReadFromJsonAsync<ProductResponse>();
            return response!;
        }

        //public async Task<ProductResponse> DeleteProductAsync(Guid productId)
        //{
        //    var product = await httpClient.GetAsync($"{BaseUrl}/product-delete/{productId}");
        //    var response = await product.Content.ReadFromJsonAsync<ProductResponse>();
        //    return response!;
        //}

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await httpClient.GetAsync($"{BaseUrl}/all");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response!;
        }

        //public async Task<ProductResponse> GetProductByIdAsync(Guid productId)
        //{
        //    var product = await httpClient.GetAsync($"{BaseUrl}/single-product/{productId}");
        //    var response = await product.Content.ReadFromJsonAsync<ProductResponse>();
        //    return response!;
        //}

        //public async Task<ProductResponse> UpdateProductAsync(Product model)
        //{
        //    var product = await httpClient.PutAsJsonAsync($"{BaseUrl}/product-update", model);
        //    var response = await product.Content.ReadFromJsonAsync<ProductResponse>();
        //    return response!;
        //}
    }
}
