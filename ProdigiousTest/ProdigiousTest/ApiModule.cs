using System;
using Ninject.Modules;
using ProdigiousTest.Entities.DataMapping.Product;
using ProdigiousTest.Entities.DataMapping.Implementation.Product;
using ProdigiousTest.Entities.DataFacade.Product;
using ProdigiousTest.Entities.DataFacade.Implementation.Product;

namespace ProdigiousTest
{
    public class ApiModule : NinjectModule
    {
        public override void Load()
        {
            //Facade
            Bind<IProductCategory>().To<ProductCategoryFacade>();
            Bind<IProduct>().To<ProductFacade>();
            Bind<IProductModel>().To<ProductModelFacade>();

            //Mapping
            Bind<IProductCategoryMapping>().To<ProductCategoryMapping>();
            Bind<IProductMapping>().To<ProductMapping>();
            Bind<IProductModelMapping>().To<ProductModelMapping>();            
        }
    }
}