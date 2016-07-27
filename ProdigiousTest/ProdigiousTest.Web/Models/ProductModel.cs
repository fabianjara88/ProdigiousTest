using System;
using System.ComponentModel.DataAnnotations;
using ProdigiousTest.Entities;

namespace ProdigiousTest.Web.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ProductNumber { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public decimal StandardCost { get; set; }

        [Required]
        public decimal ListPrice { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public decimal? Weight { get; set; }

        public int? ProductCategoryID { get; set; }
        
        public int? ProductModelID { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

        public ProductModelDto ProductModelVar { get; set; }

        [Required]
        public DateTime SellStartDate { get; set; }

        public DateTime? SellEndDate { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        [Required]
        public byte[] ThumbNailPhoto { get; set; }

        [Required]
        public string ThumbnailPhotoFileName { get; set; }

        public bool Editing { get; set; }
    }
}