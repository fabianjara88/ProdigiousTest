using System.Collections.Generic;

namespace ProdigiousTest.Entities.DataFacade.Product
{
    public interface IProductCategory
    {
        List<ProductCategoryDto> GetProductCategories();
    }
}
