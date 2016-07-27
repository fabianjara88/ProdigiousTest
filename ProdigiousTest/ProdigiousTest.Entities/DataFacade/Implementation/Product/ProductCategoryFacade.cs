using ProdigiousTest.DataAccess;
using ProdigiousTest.Entities.DataFacade.Product;
using ProdigiousTest.Entities.DataMapping.Product;
using System.Collections.Generic;
using System.Linq;

namespace ProdigiousTest.Entities.DataFacade.Implementation.Product
{
    public class ProductCategoryFacade : IProductCategory
    {
        private readonly StoreContext _context = new StoreContext();
        private readonly IProductCategoryMapping _categoryMapping;

        public ProductCategoryFacade(IProductCategoryMapping categoryMapping)
        {
            _categoryMapping = categoryMapping;
        }
        public List<ProductCategoryDto> GetProductCategories()
        {
            List<ProductCategory> productCategories = _context.ProductCategory.ToList();
            return _categoryMapping.MapDbToDtosObject(productCategories);
        }

        public ProductCategoryDto GetProductCategoryById(int productCategoryId)
        {
            ProductCategory productCategory = _context.ProductCategory.SingleOrDefault(r => r.ProductCategoryID == productCategoryId);
            return _categoryMapping.MapDbToDtoObject(productCategory);
        }
    }
}
