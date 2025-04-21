using Microsoft.EntityFrameworkCore;
using TMKStore.Data;
using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Services;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public class ProductRepos : IProduct
    {
        private readonly AppDbContext appDbContext;
        public ProductRepos(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ProductResponse> AddProductAsync(ProductDTO productDTO)
        {
            if (productDTO is null) return null!;
            var checkProduct = appDbContext.Products.Where(p => p.Title.ToLower().Equals(productDTO.Title.ToLower())).FirstOrDefaultAsync();
            if (checkProduct is null) return null!;

            appDbContext.Products.Add(
                new Product()
                {
                    Title = productDTO.Title,
                    Subtitle = productDTO.Subtitle,
                    Description = productDTO.Description,
                    Weight = productDTO.Weight,
                    StorageCondition = productDTO.StorageCondition,
                    Price = productDTO.Price,
                    Count = productDTO.Count,
                    Protein = productDTO.Protein,
                    Fats = productDTO.Fats,
                    NutritionalValue = productDTO.NutritionalValue,
                    EnergyValue = productDTO.EnergyValue,
                    SrcImageProduct = productDTO.SrcImageProduct,
                    DateTimeAdded = DateTime.Now,
                });

            await appDbContext.SaveChangesAsync();
            return new ProductResponse(true, "Продукт успешно добавлен!");
        }

        public async Task<Product> DeleteProductAsync(Guid productId)
        {
            var product = appDbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product is null) return null!;

            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync() => await appDbContext.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            var product = appDbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product is null) return null!;
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var product = appDbContext.Products.FirstOrDefault(p => p.Id == model.Id);
            if (product is null) return null!;

            product.Title = model.Title;
            product.Subtitle = model.Subtitle;
            product.Description = model.Description;
            product.Weight = model.Weight;
            product.StorageCondition = model.StorageCondition;
            product.Price = model.Price;
            product.Count = model.Count;
            product.Protein = model.Protein;
            product.Fats = model.Fats;
            product.NutritionalValue = model.NutritionalValue;
            product.EnergyValue = model.EnergyValue;

            

            return await appDbContext.Products.FirstOrDefaultAsync(p => p.Id == model.Id);
        }
    }
}
