using ProdigiousTest.Entities.DataMapping.Product;
using System.Collections.Generic;

namespace ProdigiousTest.Entities.DataMapping.Implementation.Product
{
    public class ProductMapping : IProductMapping
    {
        private readonly IProductCategoryMapping _productCategoryMapping;
        private readonly IProductModelMapping _productModelMapping;
        public ProductMapping(IProductCategoryMapping productCategoryMapping, IProductModelMapping productModelMapping)
        {
            _productCategoryMapping = productCategoryMapping;
            _productModelMapping = productModelMapping;
        }
        public ProductDto MapDbToDtoObject(DataAccess.Product product)
        {
            ProductDto productDto = new ProductDto()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                Color = product.Color,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                Size = product.Size,
                Weight = product.Weight ?? 0,
                ProductCategoryID = product.ProductCategoryID,
                ProductModelID = product.ProductModelID,
                SellStartDate = product.SellStartDate,
                DiscontinuedDate = product.DiscontinuedDate,
                ThumbNailPhoto = product.ThumbNailPhoto,
                rowguid = product.rowguid,
                ModifiedDate = product.ModifiedDate,
                ProductCategory = product.ProductCategory != null ? _productCategoryMapping.MapDbToDtoObject(product.ProductCategory): null,
                ProductModel = product.ProductModel != null ? _productModelMapping.MapDbToDtoObject(product.ProductModel): null
            };

            return productDto;
        }

        public List<ProductDto> MapDbToDtosObject(List<DataAccess.Product> products)
        {
            List<ProductDto> productsDto = new List<ProductDto>();

            foreach (var product in products)
            {
                productsDto.Add(MapDbToDtoObject(product));
            }

            return productsDto;
        }

        public List<DataAccess.Product> MapDtosToDbObject(List<ProductDto> productsDto)
        {
            List<DataAccess.Product> products = new List<DataAccess.Product>();

            foreach (var productDto in productsDto)
            {
                products.Add(MapDtoToDbObject(productDto));
            }

            return products;
        }

        public DataAccess.Product MapDtoToDbObject(ProductDto productDto)
        {
            DataAccess.Product product = new DataAccess.Product()
            {
                ProductID = productDto.ProductID,
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                Color = productDto.Color,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                Size = productDto.Size,
                Weight = productDto.Weight ?? 0,
                ProductCategoryID = productDto.ProductCategoryID,
                ProductModelID = productDto.ProductModelID,
                SellStartDate = productDto.SellStartDate,
                DiscontinuedDate = productDto.DiscontinuedDate,
                ThumbNailPhoto = productDto.ThumbNailPhoto,
                rowguid = productDto.rowguid,
                ModifiedDate = productDto.ModifiedDate,
                ProductCategory = productDto.ProductCategory != null ? _productCategoryMapping.MapDtoToDbObject(productDto.ProductCategory): null,
                ProductModel = productDto.ProductModel!= null ? _productModelMapping.MapDtoToDbObject(productDto.ProductModel): null
            };

            return product;
        }
    }
}
