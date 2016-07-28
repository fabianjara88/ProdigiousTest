using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProdigiousTest.Entities;
using System.Web.Mvc;

namespace ProdigiousTest.Web.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            ProductCategoryList =  new List<SelectListItem>();
            ProductModelList =  new List<SelectListItem>();
        }
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Number")]
        public string ProductNumber { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Standard Cost")]
        public decimal StandardCost { get; set; }

        [Required]
        [Display(Name = "List Price")]
        public decimal ListPrice { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public decimal? Weight { get; set; }

        [Display(Name = "Category")]
        public int? ProductCategoryID { get; set; }

        [Display(Name = "Model")]
        public int? ProductModelID { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

        public ProductModelDto ProductModelVar { get; set; }

        public IList<SelectListItem> ProductCategoryList { get; set; }

        public IList<SelectListItem> ProductModelList { get; set; }

        [Required]
        [Display(Name = "Sell Start Date")]
        public DateTime SellStartDate { get; set; }

        [Display(Name = "Sell End Date")]
        public DateTime? SellEndDate { get; set; }

        [Display(Name = "Discontinued Date")]
        public DateTime? DiscontinuedDate { get; set; }

        [Display(Name = "Photo")]
        public byte[] ThumbNailPhoto { get; set; }

        [Required]
        public string ThumbNailPhotoPath { get; set; }

        public string ThumbnailPhotoFileName { get; set; }

        public bool Editing { get; set; }
    }
}