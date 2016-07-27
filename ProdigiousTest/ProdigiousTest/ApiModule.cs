using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ProdigiousTest.Entities.DataMapping.Product;
using ProdigiousTest.Entities.DataMapping.Implementation.Product;
using ProdigiousTest.Entities.DataFacade.Product;
using ProdigiousTest.Entities.DataFacade.Implementation.Product;

namespace ProdigiousTest
{
    public static class ApiModule
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Facade
            container.RegisterType<IProductCategory,ProductCategoryFacade>();
            container.RegisterType<IProduct,ProductFacade>();
            container.RegisterType<IProductModel,ProductModelFacade>();

            //Mapping
            container.RegisterType<IProductCategoryMapping,ProductCategoryMapping>();
            container.RegisterType<IProductMapping,ProductMapping>();
            container.RegisterType<IProductModelMapping,ProductModelMapping>();            
        }
    }
}