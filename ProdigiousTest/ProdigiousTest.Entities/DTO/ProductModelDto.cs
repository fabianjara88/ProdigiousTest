using System;
using System.Collections.Generic;

namespace ProdigiousTest.Entities
{
    public class ProductModelDto
    {
        public int ProductModelID { get; set; }

        public string Name { get; set; }

        public string CatalogDescription { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductDto> Product { get; set; }
    }
}
