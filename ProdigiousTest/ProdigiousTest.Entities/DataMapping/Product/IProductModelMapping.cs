using ProdigiousTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
