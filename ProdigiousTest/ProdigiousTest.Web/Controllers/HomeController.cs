using System.Collections.Generic;
using System.Web.Mvc;
using ProdigiousTest.Bridge.ProductContracts;
using ProdigiousTest.Entities;
using ProdigiousTest.Web.Models;

namespace ProdigiousTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _product;
        private readonly IProductCategory _productCategory;
        private readonly IProductModel _productModel;

        public HomeController(IProduct product, IProductCategory productCategory, IProductModel productModel)
        {
            _product = product;
            _productCategory = productCategory;
            _productModel = productModel;
        }

        public ActionResult Index()
        {
            List<ProductDto> products =  _product.GetProducts();
            List<ProductModel> productListModel = new List<ProductModel>();

            if (products != null)
            {
                foreach (var product in products)
                {
                    productListModel.Add(PrepareProductModel(product));
                }
            }

            return View(productListModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ProductModel PrepareProductModel(ProductDto productDto)
        {
            ProductCategoryDto category = null;

            if (productDto.ProductCategoryID.HasValue)
                category = _productCategory.GetProductCategoryById(productDto.ProductCategoryID.Value);

            ProductModelDto model = null;

            if (productDto.ProductModelID.HasValue)
                model = _productModel.GetProductModelById(productDto.ProductModelID.Value);

            ProductModel productModel = new ProductModel
            {
                Color = productDto.Color,
                DiscontinuedDate = productDto.DiscontinuedDate,
                ListPrice = productDto.ListPrice,
                Name = productDto.Name,
                ProductCategory = category,
                ProductCategoryID = productDto.ProductCategoryID,
                ProductID = productDto.ProductID,
                ProductModelID = productDto.ProductModelID,
                ProductModelVar = model,
                ProductNumber = productDto.ProductNumber,
                SellEndDate = productDto.SellEndDate,
                SellStartDate = productDto.SellStartDate,
                Size = productDto.Size,
                StandardCost = productDto.StandardCost,
                ThumbnailPhotoFileName = productDto.ThumbnailPhotoFileName,
                ThumbNailPhoto = productDto.ThumbNailPhoto,
                Weight = productDto.Weight
            };

            return productModel;
        }
    }
}