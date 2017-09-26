using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.DataLayers.DTOs.Product
{
    public class ProductCardDTO
    {
        public string ProductId { get; set; }
        public int ProductFavorite { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRating { get; set; }
        public int ProductReview { get; set; }
        public string ProductFrontImage { get; set; }
    }
}
