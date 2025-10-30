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
        public void DataSeed()
        {
            try
            {
                if (_storeDbContext.Database.GetPendingMigrations().Any())
                {
                    _storeDbContext.Database.Migrate();
                }

                if (!_storeDbContext.ProductBrands.Any())
                {
                    var prpductBrandsData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\SeedData\brands.json");
                    //Convert  String To C# object

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(prpductBrandsData);

                    if (brands != null && brands.Any())
                    {
                        _storeDbContext.ProductBrands.AddRange(brands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var prpductTypesData = File.ReadAllText("../Infrastructure/PersistenceLayer/Data/SeedData/types.json");
                    //Convert  String To C# object

                    var types = JsonSerializer.Deserialize<List<ProductType>>(prpductTypesData);

                    if (types != null && types.Any())
                    {
                        _storeDbContext.ProductTypes.AddRange(types);
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var prpductsData = File.ReadAllText("../Infrastructure/PersistenceLayer/Data/SeedData/products.json");
                    //Convert  String To C# object

                    var products = JsonSerializer.Deserialize<List<Product>>(prpductsData);

                    if (products != null && products.Any())
                    {
                        _storeDbContext.Products.AddRange(products);
                    }
                }

                _storeDbContext.SaveChanges();
            }
            catch (Exception)
            {

                //ToDo
            }

        }
    }
}
