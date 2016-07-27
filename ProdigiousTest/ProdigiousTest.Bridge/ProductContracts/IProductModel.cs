using ProdigiousTest.Entities;
using System.Collections.Generic;

namespace ProdigiousTest.Bridge.ProductContracts
{
    public interface IProductModel
    {
        List<ProductModelDto> GetProductModels();

        ProductModelDto GetProductModelById(int productModelId);
    }
}
