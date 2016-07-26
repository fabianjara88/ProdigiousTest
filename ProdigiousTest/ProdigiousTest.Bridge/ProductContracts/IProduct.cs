using ProdigiousTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.Bridge.ProductContracts
{
    interface IProduct
    {
        #region Contracts

        void SetProduct(ProductDto productDto);
        ProductDto GetProductById(int productId);
        List<ProductDto> GetProducts();

        #endregion
    }
}
