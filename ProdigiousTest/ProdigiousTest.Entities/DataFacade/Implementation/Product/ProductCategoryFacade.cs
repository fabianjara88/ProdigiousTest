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
    }
}
