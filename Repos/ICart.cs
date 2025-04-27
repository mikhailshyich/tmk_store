using TMKStore.Models;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public interface ICart
    {
        Task<List<Cart>> GetAllCartProductAsync();
        Task<List<Cart>> GetCartByIdUserAsync(Guid userId);
        Task<bool> GetCartProductByIdAsync(Guid productId);
        Task<CartResponse> AddCartProductAsync(Guid userId, Guid productId, int productCount);
    }
}
