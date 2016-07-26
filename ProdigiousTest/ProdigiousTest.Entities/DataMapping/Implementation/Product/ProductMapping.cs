using ProdigiousTest.Entities.DataMapping.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataAccess;

namespace ProdigiousTest.Entities.DataMapping.Implementation.Product
{
    public class ProductMapping : IProductMapping
    {
        public readonly IProductCategoryMapping _productCategoryMapping;
        public readonly IProductModelMapping _productModelMapping;
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
                ProductCategoryID = product.ProductCategoryID ?? null,
                ProductModelID = product.ProductModelID ?? null,
                SellStartDate = product.SellStartDate,
                DiscontinuedDate = product.DiscontinuedDate ?? null,
                ThumbNailPhoto = product.ThumbNailPhoto,
                rowguid = product.rowguid,
                ModifiedDate = product.ModifiedDate,
                ProductCategory = _productCategoryMapping.MapDbToDtoObject(product.ProductCategory),
                ProductModel = _productModelMapping.MapDbToDtoObject(product.ProductModel)
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
                ProductCategoryID = productDto.ProductCategoryID ?? null,
                ProductModelID = productDto.ProductModelID ?? null,
                SellStartDate = productDto.SellStartDate,
                DiscontinuedDate = productDto.DiscontinuedDate ?? null,
                ThumbNailPhoto = productDto.ThumbNailPhoto,
                rowguid = productDto.rowguid,
                ModifiedDate = productDto.ModifiedDate,
                ProductCategory = _productCategoryMapping.MapDtoToDbObject(productDto.ProductCategory),
                ProductModel = _productModelMapping.MapDtoToDbObject(productDto.ProductModel)
            };

            return product;
        }
    }
}
