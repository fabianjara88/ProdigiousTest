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

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            HttpResponseMessage responseMessage;
            ProductModelDto productModelDto = _productModel.GetProductModelById(id);

            if (productModelDto == null)
            {
                string message = $"Model id = {id} not found";
                responseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, productModelDto);
            }
            return responseMessage;
        }
    }
}
