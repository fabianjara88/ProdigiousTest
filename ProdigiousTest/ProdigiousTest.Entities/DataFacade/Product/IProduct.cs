using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.Entities.DataFacade.Product
{
    public interface IProduct
    {
        List<ProductDto> GetProducts();
        void UpdateProduct(ProductDto product);
        int CreateProduct(ProductDto productDto);
        ProductDto GetProductById(int productId);
    }
}
