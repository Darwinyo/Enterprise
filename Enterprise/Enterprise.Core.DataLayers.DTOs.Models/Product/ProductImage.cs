using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Core.DataLayers.DTOs.Models.Product
{
    public class ProductImage
    {
        public string PImageId { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductImageName { get; set; }
        public int ProductImageSize { get; set; }
    }
}
