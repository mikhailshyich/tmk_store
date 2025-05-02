using static TMKStore.Responses.CustomResponses;
using TMKStore.DTOs;
using TMKStore.Data;
using TMKStore.Models;

namespace TMKStore.Repos
{
    public class OrderRepos : IOrder
    {
        private readonly AppDbContext appDbContext;
        public OrderRepos(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<OrderResponse> AddOrderAsync(Guid userId, decimal productPrice, Guid GuidCarts)
        {
            if (userId == Guid.Empty) return new OrderResponse(false, "ID пользователя пустой");
            var checkUser = appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (checkUser is null) return new OrderResponse(false, "Пользователь не найден.");
            if (GuidCarts == Guid.Empty) return new OrderResponse(false, "ID записи в корзине пустой.");

            appDbContext.Orders.Add(
                new Order()
                {
                    DateTime = DateTime.Now,
                    Price = productPrice,
                    UserId = userId,
                    CartsGuid = GuidCarts
                });
            appDbContext.SaveChanges();
            return new OrderResponse(true, "Заказ успешно добавлен");
        }
    }
}
