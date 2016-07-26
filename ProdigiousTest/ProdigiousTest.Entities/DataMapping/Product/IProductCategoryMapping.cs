using ProdigiousTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
