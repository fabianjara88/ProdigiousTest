using System.Collections.Generic;
using ProductDB = ProdigiousTest.DataAccess.Product;

namespace ProdigiousTest.Entities.DataMapping.Product
{
    public interface IProductMapping
    {
        ProductDto MapDbToDtoObject(ProductDB product);
        List<ProductDto> MapDbToDtosObject(List<ProductDB> products);
        ProductDB MapDtoToDbObject(ProductDto productDto);
        List<ProductDB> MapDtosToDbObject(List<ProductDto> productsDto);
    }
}
