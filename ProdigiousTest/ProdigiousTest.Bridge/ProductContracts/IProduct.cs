using ProdigiousTest.Entities;
using System.Collections.Generic;

namespace ProdigiousTest.Bridge.ProductContracts
{
    public interface IProduct
    {
        #region Contracts

        void SetProduct(ProductDto productDto);
        ProductDto GetProductById(int productId);
        List<ProductDto> GetProducts();

        #endregion
    }
}
