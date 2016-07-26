using ProdigiousTest.Entities;
using System.Collections.Generic;

namespace ProdigiousTest.Bridge.ProductContracts
{
    interface IProductCategory
    {
        List<ProductCategoryDto> GetProductCategories();
    }
}
