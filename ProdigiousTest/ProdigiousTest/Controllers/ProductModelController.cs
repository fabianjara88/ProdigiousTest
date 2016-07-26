using ProdigiousTest.Entities;
using ProdigiousTest.Entities.DataFacade.Product;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProdigiousTest.Controllers
{
    [RoutePrefix("api/productModel")]
    public class ProductModelController : ApiController
    {
        #region Attributes

        private readonly IProductModel _productModel;

        #endregion

        #region Constructor

        public ProductModelController(IProductModel productModel)
        {
            _productModel = productModel;
        }

        #endregion

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<ProductModelDto> productModels = _productModel.GetProductModels();

            HttpResponseMessage response = productModels == null
                ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Empty")
                : Request.CreateResponse(HttpStatusCode.OK, productModels);

            return response;
        }
    }
}
