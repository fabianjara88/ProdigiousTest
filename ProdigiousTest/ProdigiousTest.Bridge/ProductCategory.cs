using ProdigiousTest.Bridge.ProductContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProdigiousTest.Entities;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProdigiousTest.Bridge
{
    class ProductCategory : IProductCategory
    {
        private readonly string _urlScheme = ConfigurationManager.AppSettings["APIURI"];

        #region Constants

        const string UrlSchemeSpecificPath = "Product/ProductCategory";

        #endregion

        public List<ProductCategoryDto> GetProductCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(_urlScheme + UrlSchemeSpecificPath);
                List<ProductCategoryDto> productCategories = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ProductCategoryDto>>(response.Result)).Result;
                return productCategories;
            }
        }
    }
}
