using System.Collections.Generic;

namespace ProdigiousTest.Entities.DataFacade.Product
{
    public interface IProductModel
    {
        List<ProductModelDto> GetProductModels();

        ProductModelDto GetProductModelById(int productModelId);
    }
}
