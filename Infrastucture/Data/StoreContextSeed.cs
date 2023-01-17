using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Collections;
using core.Entities;

namespace Infrastucture.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrand.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastucture/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrand.Add(item);

                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductType.Any())
                {
                    var typesData = File.ReadAllText("../Infrastucture/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductType.Add(item);

                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Product.Any())
                {
                    var productsData = File.ReadAllText("../Infrastucture/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                            context.Product.Update(item);
                       
                    }
                    await context.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}