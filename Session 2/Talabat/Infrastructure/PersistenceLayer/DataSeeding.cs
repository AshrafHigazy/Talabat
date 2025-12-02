using DomanLayer.Contracts;
using DomanLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class DataSeeding(StoreDbContext _storeDbContext ) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                //Production
                if ((await _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await _storeDbContext.Database.MigrateAsync();
                }

                if (!_storeDbContext.ProductBrands.Any())
                {
                    var prpductBrandsData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\SeedData\brands.json");
                    //Convert  String To C# object

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(prpductBrandsData);

                    if (brands != null && brands.Any())
                    {
                      await  _storeDbContext.ProductBrands.AddRangeAsync(brands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    //var prpductTypesData =await File.ReadAllTextAsync("../Infrastructure/PersistenceLayer/Data/SeedData/types.json");
                    var prpductTypesData = File.OpenRead("../Infrastructure/PersistenceLayer/Data/SeedData/types.json");
                    //Type Stream

                    //Convert  String To C# object

                    var types =await JsonSerializer.DeserializeAsync<List<ProductType>>(prpductTypesData);

                    if (types != null && types.Any())
                    {
                        await _storeDbContext.ProductTypes.AddRangeAsync(types);
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var prpductsData = File.OpenRead("../Infrastructure/PersistenceLayer/Data/SeedData/products.json");
                    //Convert  String To C# object

                    var products =await JsonSerializer.DeserializeAsync<List<Product>>(prpductsData);

                    if (products != null && products.Any())
                    {
                      await  _storeDbContext.Products.AddRangeAsync(products);
                    }
                }

               await _storeDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                //ToDo
            }

        }
    }
}
