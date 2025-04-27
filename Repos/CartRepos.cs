using Microsoft.EntityFrameworkCore;
using TMKStore.Data;
using TMKStore.DTOs;
using TMKStore.Models;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public class CartRepos : ICart
    {
        private readonly AppDbContext appDbContext;

        public CartRepos(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<CartResponse> AddCartProductAsync(Guid userId, Guid productId, int productCount)
        {
            if (userId == Guid.Empty) return new CartResponse(false, "Пользователь равен null");
            if (productId == Guid.Empty) return new CartResponse(false, "Продукт равен null");
            if (productCount <= 0) return new CartResponse(false, "Количество продукта должно быть больше 0");

            var checkUser = appDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (checkUser is null) return new CartResponse(false, "Пользователь не найден");

            var checkProduct = appDbContext.Products.Where(p => p.Id == productId).FirstOrDefault();
            if (checkProduct is null) return new CartResponse(false, "Продукт не найден");

            if (checkProduct.Count < productCount)
            {
                return new CartResponse(false, "Желаемое количество продукта больше фактического");
            }
            else
            {
                checkProduct.Count -= productCount;
            }

            var checkCart = appDbContext.Carts.FirstOrDefault(c => c.UserId == userId & c.ProductId == productId);

            if (checkCart != null)
            {
                checkCart.Count += productCount;
                checkCart.DateAdded = DateTime.Now;
            }
            else
            {
                appDbContext.Carts.Add(
                    new Cart
                    {
                        UserId = checkUser.Id,
                        ProductId = checkProduct.Id,
                        Count = productCount,
                        DateAdded = DateTime.Now,
                    });
            }

            appDbContext.SaveChanges();
            return new CartResponse(true, "Продукт успешно добавлен в корзину");
        }

        public Task<List<Cart>> GetAllCartProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cart>> GetCartByIdUserAsync(Guid userId)
        {
            if (userId == Guid.Empty) return null!;
            var checkCart = await appDbContext.Carts.Where(c => c.UserId == userId).ToListAsync();
            if (checkCart.Count <= 0) return null!;
            //var productsList = new List<Product>();

            //foreach (var product in checkCart)
            //{
            //    productsList.Add(appDbContext.Products.FirstOrDefault(p => p.Id == product.ProductId));
            //}

            return checkCart;
        }

        public async Task<bool> GetCartProductByIdAsync(Guid productId)
        {
            if (productId == Guid.Empty) return false;
            var checkCartProduct = appDbContext.Carts.FirstOrDefault(c => c.ProductId == productId);
            if(checkCartProduct == null) return false;
            return true;
        }
    }
}
