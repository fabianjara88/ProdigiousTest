using ProdigiousTest.Entities;
using ProdigiousTest.Entities.DataFacade.Product;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProdigiousTest.Controllers
{
    [RoutePrefix("api/productCategory")]
    public class ProductCategoryController : ApiController
    {
        #region Attributes

        private readonly IProductCategory _productCategory;

        #endregion

        #region Constructor

        public ProductCategoryController(IProductCategory productCategory)
        {
            _productCategory = productCategory;
        }

        #endregion

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<ProductCategoryDto> productCategories = _productCategory.GetProductCategories();

            HttpResponseMessage response = productCategories == null
                ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Empty")
                : Request.CreateResponse(HttpStatusCode.OK, productCategories);

            return response;
        }
    }
}
