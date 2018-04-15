using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    public class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.CatalogBrands.Any())
            {
                context.CatalogBrands.AddRange(GetPreconfiguredCatalogBrands());
                await context.SaveChangesAsync();
            }

            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes.AddRange(GetPreconfiguredCatalogTypes());
                await context.SaveChangesAsync();
            }

            if (!context.CatalogItems.Any())
            {
                context.CatalogItems.AddRange(GetPreconfiguredCatalogItems());
                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Brand = "Addidas" },
                new CatalogBrand() { Brand = "Puma" },
                new CatalogBrand() { Brand = "Slazenger" }
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Running" },
                new CatalogType() { Type = "Basketball" },
                new CatalogType() { Type = "Tennis" }
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredCatalogItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 3, Description = "Shoes for next century", Name = "World Star", Price= Convert.ToDecimal(15.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/1"},
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 2, Description = "Will make you world champions", Name = "White Line", Price= Convert.ToDecimal(25.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/2"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 3, Description = "You have already won gold medal", Name = "Prism White", Price= Convert.ToDecimal(45.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/3"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 2, Description = "Olympic Runner", Name = "Foundation Hitech", Price= Convert.ToDecimal(55.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/4"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 1, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price= Convert.ToDecimal(65.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 2, Description = "Lala Land", Name = "Blue Star", Price= Convert.ToDecimal(5.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 1, Description = "High in the sky", Name = "Roslyn Green", Price= Convert.ToDecimal(4.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 1, Description = "Light as carbon", Name = "Deep Purple", Price= Convert.ToDecimal(19.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/8"},
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 2, Description = "High Jumper", Name = "Addidas<White> Running", Price= Convert.ToDecimal(22.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 3, Description = "Dunker", Name = "Elequent", Price= Convert.ToDecimal(23.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 2, Description = "All round", Name = "Incredible", Price= Convert.ToDecimal(80.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/11"},
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 1, Description = "Pricesless", Name = "London Sky", Price= Convert.ToDecimal(95.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 3, Description = "Tennis Star", Name = "Elequent", Price= Convert.ToDecimal(105.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/13"},
                new CatalogItem() { CatalogTypeId = 3, CatalogBrandId = 2, Description = "Wimbeldon", Name = "London Star", Price= Convert.ToDecimal(11.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new CatalogItem() { CatalogTypeId = 3, CatalogBrandId = 1, Description = "Rolan Garros", Name = "Paris Garros", Price= Convert.ToDecimal(18.99), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/15"}
            };
        }
    }
}
