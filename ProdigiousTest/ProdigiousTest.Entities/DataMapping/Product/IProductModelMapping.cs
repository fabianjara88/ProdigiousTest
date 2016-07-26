using ProdigiousTest.DataAccess;
using System.Collections.Generic;

namespace ProdigiousTest.Entities.DataMapping.Product
{
    public interface IProductModelMapping
    {
        ProductModelDto MapDbToDtoObject(ProductModel productModel);
        List<ProductModelDto> MapDbToDtosObject(List<ProductModel> productModels);
        ProductModel MapDtoToDbObject(ProductModelDto productModelDto);
        List<ProductModel> MapDtosToDbObject(List<ProductModelDto> productModelsDto);
    }
}
