using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public interface IOrder
    {
        Task<OrderResponse> AddOrderAsync(Guid userId, decimal productPrice, Guid GuidCarts);
    }
}
