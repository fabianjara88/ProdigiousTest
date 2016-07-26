using ProdigiousTest.Entities.DataMapping.Product;
using System;
using System.Collections.Generic;
using ProdigiousTest.DataAccess;

namespace ProdigiousTest.Entities.DataMapping.Implementation.Product
{
    public class ProductCategoryMapping : IProductCategoryMapping
    {
        public ProductCategoryDto MapDbToDtoObject(ProductCategory productCategory)
        {
            ProductCategoryDto productCategoryDto = new ProductCategoryDto()
            {
                ProductCategoryID = productCategory.ProductCategoryID,
                Name = productCategory.Name
            };

            return productCategoryDto;
        }

        public List<ProductCategoryDto> MapDbToDtosObject(List<ProductCategory> productCategories)
        {
            List<ProductCategoryDto> productCategoriesDto = new List<ProductCategoryDto>();

            foreach (var productCategory in productCategories)
            {
                productCategoriesDto.Add(MapDbToDtoObject(productCategory));
            }

            return productCategoriesDto;
        }

        public List<ProductCategory> MapDtosToDbObject(List<ProductCategoryDto> productCategoriesDto)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();

            foreach (var productCategoryDto in productCategoriesDto)
            {
                productCategories.Add(MapDtoToDbObject(productCategoryDto));
            }

            return productCategories;
        }

        public ProductCategory MapDtoToDbObject(ProductCategoryDto productCategoryDto)
        {
            ProductCategory productCategory = new ProductCategory()
            {
                ProductCategoryID = productCategoryDto.ProductCategoryID,
                Name = productCategoryDto.Name,
                ModifiedDate = productCategoryDto.ModifiedDate,
                rowguid = productCategoryDto.rowguid,
                ParentProductCategoryID = productCategoryDto.ParentProductCategoryID ?? null
            };

            return productCategory;
        }
    }
}
