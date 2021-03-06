﻿using System.Collections.Generic;
using ProdigiousTest.Entities.DataFacade.Product;
using ProdigiousTest.DataAccess;
using ProdigiousTest.Entities.DataMapping.Product;
using System.Linq;

namespace ProdigiousTest.Entities.DataFacade.Implementation.Product
{
    public class ProductModelFacade : IProductModel
    {
        private readonly StoreContext _context = new StoreContext();
        private readonly IProductModelMapping _modelMapping;

        public ProductModelFacade(IProductModelMapping modelMapping)
        {
            _modelMapping = modelMapping;
        }

        public List<ProductModelDto> GetProductModels()
        {
            List<ProductModel> productModels = _context.ProductModel.ToList();
            return _modelMapping.MapDbToDtosObject(productModels);
        }

        public ProductModelDto GetProductModelById(int productModelId)
        {
            ProductModel productModel = _context.ProductModel.SingleOrDefault(r => r.ProductModelID == productModelId);

            if(productModel != null)
                return _modelMapping.MapDbToDtoObject(productModel);
            return null;
        }
    }
}
