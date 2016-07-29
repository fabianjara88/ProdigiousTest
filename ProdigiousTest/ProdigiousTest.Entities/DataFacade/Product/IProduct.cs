using System.Collections.Generic;

namespace ProdigiousTest.Entities.DataFacade.Product
{
    public interface IProduct
    {
        List<ProductDto> GetProducts();
        void UpdateProduct(ProductDto product);
        int CreateProduct(ProductDto productDto);
        ProductDto GetProductById(int productId);
        bool IsValidProduct(string name, string productNumber, int productId);
    }
}
