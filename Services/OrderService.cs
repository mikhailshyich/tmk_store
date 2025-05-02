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

        public async Task<OrderResponse> AddOrderAsync(Guid userId, decimal productPrice, Guid GuidCarts)
        {
            var order = await httpClient.PostAsJsonAsync($"{BaseUrl}/add", GuidCarts);
            var response = await order.Content.ReadFromJsonAsync<OrderResponse>();
            return response!;
        }
    }
}
