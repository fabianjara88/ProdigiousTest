using ProdigiousTest.DataAccess;
using ProdigiousTest.Entities.DataFacade.Product;
using ProdigiousTest.Entities.DataMapping.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                product.ProductCategoryID = productDto.ProductCategoryID ?? null;
                product.ProductModelID = productDto.ProductModelID ?? null;
                product.SellStartDate = productDto.SellStartDate;
                product.DiscontinuedDate = productDto.DiscontinuedDate ?? null;
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

            int result = _context.SaveChanges();
            return result;
        }

        public ProductDto GetProductById(int productId)
        {
            DataAccess.Product product = GetFromProduct(productId);
            return _productMapping.MapDbToDtoObject(product);
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
            product.ProductCategoryID = productDto.ProductCategoryID ?? null;
            product.ProductModelID = productDto.ProductModelID ?? null;
            product.SellStartDate = productDto.SellStartDate;
            product.DiscontinuedDate = productDto.DiscontinuedDate ?? null;
            product.ThumbNailPhoto = productDto.ThumbNailPhoto;
            product.rowguid = productDto.rowguid;
            product.ModifiedDate = DateTime.Now;

            _context.SaveChanges();
        }

        private DataAccess.Product GetFromProduct(int productId)
        {
            return _context.Product.FirstOrDefault(r => r.ProductID == productId); ;
        }
    }
}
