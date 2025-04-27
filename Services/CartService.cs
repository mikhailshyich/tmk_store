using static TMKStore.Responses.CustomResponses;
using TMKStore.DTOs;
using TMKStore.Repos;
using TMKStore.Models;

namespace TMKStore.Services
{
    public class CartService : ICart
    {
        private readonly HttpClient httpClient;

        public CartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private const string BaseUrl = "api/cart";

        public Task<List<Cart>> GetAllCartProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cart>> GetCartByIdUserAsync(Guid userId)
        {
            var cart = await httpClient.GetAsync($"{BaseUrl}/user/{userId}");
            var response = await cart.Content.ReadFromJsonAsync<List<Cart>>();
            return response!;
        }

        public async Task<CartResponse> AddCartProductAsync(Guid userId, Guid porductId, int productCount)
        {
            var seriliazeValue = new List<Guid>();
            seriliazeValue.Add(userId);
            seriliazeValue.Add(porductId);

            var cart = await httpClient.PostAsJsonAsync($"{BaseUrl}/add", seriliazeValue);
            var response = await cart.Content.ReadFromJsonAsync<CartResponse>();
            return response!;
        }

        public async Task<bool> GetCartProductByIdAsync(Guid productId)
        {
            var cart = await httpClient.GetAsync($"{BaseUrl}/product/{productId}");
            var response = await cart.Content.ReadFromJsonAsync<bool>();
            return response!;
        }
    }
}
