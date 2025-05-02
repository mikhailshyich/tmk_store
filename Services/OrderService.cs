using TMKStore.Components.Pages;
using TMKStore.Models;
using TMKStore.Repos;
using TMKStore.Responses;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Services
{
    public class OrderService : IOrder
    {
        private readonly HttpClient httpClient;

        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private const string BaseUrl = "api/order";

        public async Task<OrderResponse> AddOrderAsync(Guid userId, decimal productPrice, int productCount, Guid productId, Guid uniqueGuid)
        {
            var order = await httpClient.PostAsJsonAsync($"{BaseUrl}/add", productId);
            var response = await order.Content.ReadFromJsonAsync<OrderResponse>();
            return response!;
        }

        public async Task<List<Order>> GetOrdersUserByIdAsync(Guid userId)
        {
            var order = await httpClient.PostAsJsonAsync($"{BaseUrl}/get", userId);
            var response = await order.Content.ReadFromJsonAsync<List<Order>>();
            return response!;
        }
    }
}
