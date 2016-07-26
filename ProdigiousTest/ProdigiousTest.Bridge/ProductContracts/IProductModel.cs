using ProdigiousTest.Entities;
using System.Collections.Generic;

namespace ProdigiousTest.Bridge.ProductContracts
{
    interface IProductModel
    {
        List<ProductModelDto> GetProductModels();
    }
}
