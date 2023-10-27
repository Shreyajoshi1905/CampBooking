using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastucture.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context){

            if(!context.CampCities.Any()){
                var City = File.ReadAllText("../Infrastucture/Data/SeedData/Cities.json");
                var cities = JsonSerializer.Deserialize<List<CampCity>>(City);
                context.CampCities.AddRange(cities);
            }
            if(!context.Products.Any()){
                var campData = File.ReadAllText("../Infrastucture/Data/SeedData/products.json");
                var camps = JsonSerializer.Deserialize<List<ProductModel>>(campData);
                context.Products.AddRange(camps);
            }
            if(context.ChangeTracker.HasChanges()){
                await context.SaveChangesAsync();
            }
        }
    }
}