using Enterprise.DataLayers.DTOs.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.DataLayers.DTOs.Product
{
    public class ProductDetailsDTO
    {
        public string ProductId { get; set; }
        public int ProductFavorite { get; set; }
        public int ProductLocation { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRating { get; set; }
        public int ProductReview { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }

        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<ProductSpec> ProductSpecs { get; set; }
        public IEnumerable<ProductVariationItem> ProductVariations { get; set; }
    }
}
