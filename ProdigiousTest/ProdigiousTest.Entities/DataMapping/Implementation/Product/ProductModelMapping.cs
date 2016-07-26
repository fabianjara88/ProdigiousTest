using ProdigiousTest.Entities.DataMapping.Product;
using System.Collections.Generic;
using ProdigiousTest.DataAccess;

namespace ProdigiousTest.Entities.DataMapping.Implementation.Product
{
    public class ProductModelMapping : IProductModelMapping
    {
        public ProductModelDto MapDbToDtoObject(ProductModel productModel)
        {
            ProductModelDto productModelDto = new ProductModelDto()
            {
                ProductModelID = productModel.ProductModelID,
                Name = productModel.Name,
                CatalogDescription = productModel.CatalogDescription,
                rowguid = productModel.rowguid,
                ModifiedDate = productModel.ModifiedDate
            };

            return productModelDto;
        }

        public List<ProductModelDto> MapDbToDtosObject(List<ProductModel> productModels)
        {
            List<ProductModelDto> productModelsDto = new List<ProductModelDto>();

            foreach (var productModel in productModels)
            {
                productModelsDto.Add(MapDbToDtoObject(productModel));
            }

            return productModelsDto;
        }

        public List<ProductModel> MapDtosToDbObject(List<ProductModelDto> productModelsDto)
        {
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var productModelDto in productModelsDto)
            {
                productModels.Add(MapDtoToDbObject(productModelDto));
            }

            return productModels;
        }

        public ProductModel MapDtoToDbObject(ProductModelDto productModelDto)
        {
            ProductModel productModel = new ProductModel()
            {
                ProductModelID = productModelDto.ProductModelID,
                Name = productModelDto.Name,
                CatalogDescription = productModelDto.CatalogDescription,
                rowguid = productModelDto.rowguid,
                ModifiedDate = productModelDto.ModifiedDate
            };

            return productModel;
        }
    }
}
