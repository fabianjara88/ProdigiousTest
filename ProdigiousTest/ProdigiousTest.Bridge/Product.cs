using ProdigiousTest.Bridge.ProductContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.Entities;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProdigiousTest.Bridge
{
    public class Product : IProduct
    {
        private readonly string _urlScheme = ConfigurationManager.AppSettings["APIURI"];

        #region Constants

        const string UrlSchemeSpecificPath = "Product";

        #endregion

        public ProductDto GetProductById(int productId)
        {
            ProductDto productDto;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Task<string> response = client.GetStringAsync(_urlScheme + UrlSchemeSpecificPath + "/" + productId + "/");
                    productDto = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductDto>(response.Result)).Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

            return productDto;
        }

        public List<ProductDto> GetProducts()
        {
            List<ProductDto> productsDto;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Task<string> response = client.GetStringAsync(_urlScheme + UrlSchemeSpecificPath);
                    productsDto = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ProductDto>>(response.Result)).Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

            return productsDto;
        }

        public int SetProduct(ProductDto productDto)
        {
            try
            {
                int productId = 0;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.PostAsync(_urlScheme + UrlSchemeSpecificPath, new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        productId = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                return productId;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsValidProduct(ProductDto productDto)
        {
            bool isValidProduct;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Task<string> response = client.GetStringAsync(_urlScheme + UrlSchemeSpecificPath + "/" + productDto.Name + "/" + productDto.ProductNumber + "/" + productDto.ProductID + "/");
                    isValidProduct = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<bool>(response.Result)).Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

            return isValidProduct;
        }
    }
}
