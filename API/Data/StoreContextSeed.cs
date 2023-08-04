/*using API.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;


namespace API.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            
                *//*var brandsData = File.ReadAllText(path + "../Data/SeedData/types.json");*/
                /* var brandsData = File.ReadAllText(path + @"/Data/SeedData/brands.json");*//*
                var brandsData = File.ReadAllText(Path.Combine(path, "Data", "SeedData", "brands.json"));
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
           
                *//*var typesData = File.ReadAllText(path + "../Data/SeedData/types.json");*/
                /* var typesData = File.ReadAllText(path + @"/Data/SeedData/types.json");*//*
                var typesData = File.ReadAllText(Path.Combine(path, "Data", "SeedData", "types.json"));
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
           
                *//* var productsData = File.ReadAllText(path + "../Data/SeedData/products.json");*/
                /*var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");*//*
                var productsData = File.ReadAllText(Path.Combine(path, "Data", "SeedData", "products.json"));   
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);

                context.SaveChanges();

        }
    }
}

*/