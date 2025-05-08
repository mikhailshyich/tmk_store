using TMKStore.Models;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public interface IOrder
    {
        Task<OrderResponse> AddOrderAsync(Guid userId, decimal productPrice, int productCount, Guid productId, Guid uniqueGuid);
        Task<List<Order>> GetOrdersUserByIdAsync(Guid userId);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
