using ProdigiousTest.Entities;
using System.Collections.Generic;

namespace ProdigiousTest.Bridge.ProductContracts
{
    public interface IProductCategory
    {
        List<ProductCategoryDto> GetProductCategories();

        ProductCategoryDto GetProductCategoryById(int productCategoryId);
    }
}
