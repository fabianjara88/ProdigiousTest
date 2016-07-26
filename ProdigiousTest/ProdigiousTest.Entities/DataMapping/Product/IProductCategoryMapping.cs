using ProdigiousTest.DataAccess;
using System.Collections.Generic;

namespace ProdigiousTest.Entities.DataMapping.Product
{
    public interface IProductCategoryMapping
    {
        ProductCategoryDto MapDbToDtoObject(ProductCategory productCategory);
        List<ProductCategoryDto> MapDbToDtosObject(List<ProductCategory> productCategories);
        ProductCategory MapDtoToDbObject(ProductCategoryDto productCategoryDto);
        List<ProductCategory> MapDtosToDbObject(List<ProductCategoryDto> productCategoriesDto);
    }
}
