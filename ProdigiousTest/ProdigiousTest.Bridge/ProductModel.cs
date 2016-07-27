using System;
using ProdigiousTest.Bridge.ProductContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProdigiousTest.Entities;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;

namespace ProdigiousTest.Bridge
{
    public class ProductModel : IProductModel
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

        public ProductModelDto GetProductModelById(int productId)
        {
            ProductModelDto productModelDto;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Task<string> response = client.GetStringAsync(_urlScheme + UrlSchemeSpecificPath + "/" + productId + "/");
                    productModelDto = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductModelDto>(response.Result)).Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

            return productModelDto;
        }
    }
}
