using ProdigiousTest.DataAccess;
using System;
using System.Collections.Generic;

namespace ProdigiousTest.Entities
{
    public partial class ProductCategoryDto
    {
        public int ProductCategoryID { get; set; }

        public int? ParentProductCategoryID { get; set; }

        public string Name { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<ProductDto> Product { get; set; }

        public virtual ICollection<ProductCategoryDto> ProductCategory1 { get; set; }

        public virtual ProductCategoryDto ProductCategory2 { get; set; }
    }
}
