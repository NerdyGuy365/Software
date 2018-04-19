using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesOnContainers.Web.WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static string GetAllCatalogItems(string baseUri, int page, int take, int? brand, int? type)
        {
            var filterQs = "";

            if(brand.HasValue || type.HasValue)
            {
                var brandsQs = (brand.HasValue) ? brand.Value.ToString() : "null";
                var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                filterQs = $"/type/{typeQs}/brand/{brandsQs}";
            }

            return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
        }

        public static string GetCatalogItem(string baseUri, int id)
        {
            return $"{baseUri}items/{id}";
        }

        public static string GetAllBrands(string baseUri)
        {
            return $"{baseUri}catalogbrands";
        }

        public static string GetAllTypes(string baseUri)
        {
            return $"{baseUri}catalogTypes";
        }
    }
}
