using System.Collections.Generic;
using System.IO;
using System.Web;
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

        public ActionResult View(int productId)
        {
            if (productId == 0)
                RedirectToAction("index");

            ProductDto productDto = _product.GetProductById(productId);

            if(productDto != null)
                RedirectToAction("index");

            ProductModel productModel = PrepareProductModel(productDto);

            return View(productModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "Create Product";
            ProductModel productModel = new ProductModel();
            var categories = _productCategory.GetProductCategories();

            productModel.ProductModelList.Add(new SelectListItem
            {
                Text = "None",
                Value = "0"
            });

            foreach (var category in categories)
            {
                productModel.ProductCategoryList.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.ProductCategoryID.ToString(),
                    Selected = true
                });
            }

            var models = _productModel.GetProductModels();

            productModel.ProductCategoryList.Add(new SelectListItem
            {
                Text = "None",
                Value = "0",
                Selected = true
            });

            foreach (var model in models)
            {
                productModel.ProductCategoryList.Add(new SelectListItem
                {
                    Text = model.Name,
                    Value = model.ProductModelID.ToString()
                });
            }

            return View(productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product, HttpPostedFileBase thumbNailPhotoPath)
        {
            if (ModelState.IsValid)
            {
                byte[] bytes = null;
                string photoName = null;

                if (thumbNailPhotoPath != null && thumbNailPhotoPath.ContentLength > 0)
                {
                    photoName = Path.GetFileName(thumbNailPhotoPath.FileName);



                    string path = Path.Combine(Server.MapPath("~/Content/"), "bt_fb.png");

                    //if (!Directory.Exists(Server.MapPath("~/Content/temp/")))
                    //    Directory.CreateDirectory(Server.MapPath("~/Content/temp/"));

                    //thumbNailPhotoPath.SaveAs(path);

                    bytes = System.IO.File.ReadAllBytes(path);

                    //System.IO.File.Delete(path);
                }

                ProductDto productDto = new ProductDto
                {
                    DiscontinuedDate = product.DiscontinuedDate,
                    Color = product.Color,
                    ProductModelID = product.ProductModelID,
                    ListPrice = product.ListPrice,
                    Name = product.Name,
                    ProductCategoryID = product.ProductCategoryID,
                    ProductNumber = product.ProductNumber,
                    SellEndDate = product.SellEndDate,
                    SellStartDate = product.SellStartDate,
                    Size = product.Size,
                    StandardCost = product.StandardCost,
                    ThumbNailPhoto = bytes,
                    ThumbnailPhotoFileName = photoName,
                    Weight = product.Weight
                };

                int productId = _product.SetProduct(productDto);

                return RedirectToAction("View", "Home", new { productId = productId });
            }

            return RedirectToAction("Index");
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