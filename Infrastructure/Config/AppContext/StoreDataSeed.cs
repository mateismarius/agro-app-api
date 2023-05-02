using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.AppContext
{
    public class StoreDataSeed
    {
        public static async Task SeedAsync(ApplicationContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/SeedData/types.json");
                var brands = JsonSerializer.Deserialize<List<ProductType>>(brandsData);
                context.ProductTypes.AddRange(brands);
            }
            if (!context.Products.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/SeedData/products.json");
                var brands = JsonSerializer.Deserialize<List<Product>>(brandsData);
                context.Products.AddRange(brands);
            }
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
