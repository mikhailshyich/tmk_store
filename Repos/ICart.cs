using TMKStore.Models;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public interface ICart
    {
        /// <summary>
        /// Получить все записи в корзине.
        /// </summary>
        /// <returns>Список записей.</returns>
        Task<List<Cart>> GetAllCartProductAsync();

        /// <summary>
        /// Получить все записи в корзине для конкретного пользователя.
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Список записей.</returns>
        Task<List<Cart>> GetCartByIdUserAsync(Guid userId);

        /// <summary>
        /// Проверка наличия продукта в корзине у пользователей.
        /// </summary>
        /// <param name="productId">ID продукта</param>
        /// <returns>True - если продукт есть у кого-то в корзине, False - если продукта в корзине нет.</returns>
        Task<bool> GetCartProductByIdAsync(Guid productId);

        /// <summary>
        /// Добавить продукт в корзину конкретному пользователю
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="productId">ID продукта</param>
        /// <param name="productCount">Количество продукта</param>
        /// <returns>Ответ об успешном или не успешном добавлении продукта в корзину.</returns>
        Task<CartResponse> AddCartProductAsync(Guid userId, Guid productId, int productCount);

        /// <summary>
        /// Удалить продукт из корзины.
        /// </summary>
        /// <param name="cartId">ID записи в корзине</param>
        /// <returns>Ответ об успешном или не успешном удалении продукта из корзины</returns>
        Task<CartResponse> DeleteCartProductAsync(Guid cartId);

        Task<CartResponse> UpdateCartRecordAsync(Guid cartId, int updateCount);

    }
}
