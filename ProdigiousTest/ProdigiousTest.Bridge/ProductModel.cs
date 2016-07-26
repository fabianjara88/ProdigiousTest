using ProdigiousTest.Bridge.ProductContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.Entities;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;

namespace ProdigiousTest.Bridge
{
    class ProductModel : IProductModel
    {
        private readonly string _urlScheme = ConfigurationManager.AppSettings["APIURI"];

        #region Constants

        const string UrlSchemeSpecificPath = "Product/ProductCategory";

        #endregion

        public List<ProductModelDto> GetProductModels()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(_urlScheme + UrlSchemeSpecificPath);
                List<ProductModelDto> productModels = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ProductModelDto>>(response.Result)).Result;
                return productModels;
            }
        }
    }
}
