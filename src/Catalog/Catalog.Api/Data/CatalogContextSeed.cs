using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> products) 
        {
            bool existproducts = products.Find(x => true).Any();
            if (!existproducts)
            {
                products.InsertManyAsync(GetProducts());
            }
        }
        private static IEnumerable<Product> GetProducts()
        {
            return new List<Product> { 
                new Product { Category = "Computers", Description = "desc", ImageFile = "image", Name = "Hp", Price = 500, Summary = "Summary" } ,
                new Product { Category = "Computers", Description = "desc", ImageFile = "image", Name = "MacBook", Price = 2500, Summary = "Summary" } ,
                new Product { Category = "Computers", Description = "desc", ImageFile = "image", Name = "Acer", Price = 2000, Summary = "Summary" } 
            };
        }
    }
}
