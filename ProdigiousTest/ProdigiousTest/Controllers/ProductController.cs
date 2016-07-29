using ProdigiousTest.Entities;
using ProdigiousTest.Entities.DataFacade.Product;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProdigiousTest.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {

        #region Attributes

        private readonly IProduct _product;

        #endregion

        #region Constructor

        public ProductController(IProduct product)
        {
            _product = product;
        }

        #endregion

        [HttpGet]
        [Route("")]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _product.GetProducts();
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetProductById(int id)
        {
            HttpResponseMessage responseMessage;
            ProductDto productDto = _product.GetProductById(id);

            if (productDto == null)
            {
                string message = $"Product id = {id} not found";
                responseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, productDto);
            }
            return responseMessage;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ProductDto productDto)
        {
            HttpResponseMessage response;

            if (ModelState.IsValid)
            {
                response = Request.CreateResponse(HttpStatusCode.Accepted, productDto.Editing ? UpdateProduct(productDto) : CreateProduct(productDto));
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }

        [HttpGet]
        [Route("{name}/{productNumber}/{productId:int}")]
        public HttpResponseMessage IsValidProduct(string name, string productNumber,  int productId)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, _product.IsValidProduct(name, productNumber, productId));
            return response;
        }

        private HttpResponseMessage UpdateProduct(ProductDto productDto)
        {
            _product.UpdateProduct(productDto);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, productDto);
            return response;
        }

        private HttpResponseMessage CreateProduct(ProductDto productDto)
        {
            _product.CreateProduct(productDto);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productDto);
            return response;
        }
    }
}
