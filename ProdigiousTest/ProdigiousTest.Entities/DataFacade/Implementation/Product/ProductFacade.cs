using ProdigiousTest.DataAccess;
using ProdigiousTest.Entities.DataFacade.Product;
using ProdigiousTest.Entities.DataMapping.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProdigiousTest.Entities.DataFacade.Implementation.Product
{
    public class ProductFacade : IProduct
    {
        private readonly StoreContext _context = new StoreContext();
        private readonly IProductMapping _productMapping;

        #region Constructor

        public ProductFacade(IProductMapping productMapping)
        {
            _productMapping = productMapping;
        }

        #endregion
        public int CreateProduct(ProductDto productDto)
        {
            DataAccess.Product product = GetFromProduct(productDto.ProductID);

            if (product != null)
            {
                product.Name = productDto.Name;
                product.ProductNumber = productDto.ProductNumber;
                product.Color = productDto.Color;
                product.StandardCost = productDto.StandardCost;
                product.ListPrice = productDto.ListPrice;
                product.Size = productDto.Size;
                product.Weight = productDto.Weight ?? 0;
                product.ProductCategoryID = productDto.ProductCategoryID;
                product.ProductModelID = productDto.ProductModelID;
                product.SellStartDate = productDto.SellStartDate;
                product.DiscontinuedDate = productDto.DiscontinuedDate;
                product.ThumbNailPhoto = productDto.ThumbNailPhoto;
                product.rowguid = productDto.rowguid;
                product.ModifiedDate = DateTime.Now;
            }
            else
            {
                productDto.rowguid = Guid.NewGuid();
                productDto.ModifiedDate = DateTime.Now;
                product = _productMapping.MapDtoToDbObject(productDto);
                _context.Product.Add(product);
            }

            _context.SaveChanges();
            return product.ProductID;
        }

        public ProductDto GetProductById(int productId)
        {
            DataAccess.Product product = GetFromProduct(productId);

            if(product != null)
                return _productMapping.MapDbToDtoObject(product);
            return null;
        }

        public bool IsValidProduct(string name, string productNumber, int productId)
        {
            DataAccess.Product product =  _context.Product.FirstOrDefault(r => r.Name == name || r.ProductNumber == productNumber);

            if (product == null)
                return true;

            if (product.ProductID != productId)
                return false;

            return true;
        }

        public List<ProductDto> GetProducts()
        {
            List<DataAccess.Product> products = _context.Product.ToList();
            return _productMapping.MapDbToDtosObject(products);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            DataAccess.Product product = GetFromProduct(productDto.ProductID);

            product.Name = productDto.Name;
            product.ProductNumber = productDto.ProductNumber;
            product.Color = productDto.Color;
            product.StandardCost = productDto.StandardCost;
            product.ListPrice = productDto.ListPrice;
            product.Size = productDto.Size;
            product.Weight = productDto.Weight ?? 0;
            product.ProductCategoryID = productDto.ProductCategoryID;
            product.ProductModelID = productDto.ProductModelID;
            product.SellStartDate = productDto.SellStartDate;
            product.DiscontinuedDate = productDto.DiscontinuedDate;
            product.ThumbNailPhoto = productDto.ThumbNailPhoto;
            product.ModifiedDate = DateTime.Now;

            _context.SaveChanges();
        }

        private DataAccess.Product GetFromProduct(int productId)
        {
            return _context.Product.FirstOrDefault(r => r.ProductID == productId);
        }
    }
}
