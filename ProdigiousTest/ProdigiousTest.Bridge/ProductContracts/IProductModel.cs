using ProdigiousTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.Bridge.ProductContracts
{
    interface IProductModel
    {
        List<ProductModelDto> GetProductModels();
    }
}
