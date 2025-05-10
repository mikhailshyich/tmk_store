using static TMKStore.Responses.CustomResponses;
using TMKStore.DTOs;
using TMKStore.Data;
using TMKStore.Models;
using TMKStore.Components.Pages;
using Microsoft.EntityFrameworkCore;

namespace TMKStore.Repos
{
    public class OrderRepos : IOrder
    {
        private readonly AppDbContext appDbContext;
        public OrderRepos(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<OrderResponse> AddOrderAsync(Guid userId, decimal productPrice, int productCount, Guid productId, Guid uniqueGuid)
        {
            if (userId == Guid.Empty) return new OrderResponse(false, "ID пользователя пустой");
            var checkUser = appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (checkUser is null) return new OrderResponse(false, "Пользователь не найден.");
            if (productId == Guid.Empty) return new OrderResponse(false, "ID продукта пустой.");
            var checkProduct = appDbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (checkProduct is null) return new OrderResponse(false, "Продукт не найден.");

            appDbContext.Orders.Add(
                new Order()
                {
                    DateTime = DateTime.Now,
                    ProductPrice = productPrice,
                    ProductCount = productCount,
                    UserId = userId,
                    ProductId = productId,
                    UniqueGuid = uniqueGuid,
                    Product = checkProduct,
                });
            checkProduct.Count -= productCount;
            appDbContext.SaveChanges();
            return new OrderResponse(true, "Заказ успешно добавлен");
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            if (id <= 0) return null!;
            var checkOrder = appDbContext.Orders.FirstOrDefault(o => o.Id == id);
            if(checkOrder is null) return null!;
            return checkOrder;
        }

        public async Task<List<Order>> GetOrdersUserByIdAsync(Guid userId)
        {
            if (userId == Guid.Empty) return null!;
            var checkUser = appDbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (checkUser is null) return null!;
            var checkOrder = await appDbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
            if (checkOrder is null) return null!;

            return checkOrder;
        }

        public async Task<List<Order>> GetUniqueOrdersByIdAsync(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty) return null!;
            var checkOrder = appDbContext.Orders.Where(o => o.UniqueGuid == uniqueId).ToList();
            if (checkOrder is null) return null!;
            foreach (var order in checkOrder)
            {
                order.Product = appDbContext.Products.FirstOrDefault(p => p.Id == order.ProductId);
            }
            return checkOrder;
        }
    }
}
