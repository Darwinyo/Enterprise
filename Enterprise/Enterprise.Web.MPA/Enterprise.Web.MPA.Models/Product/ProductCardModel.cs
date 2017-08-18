using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Web.MPA.Models.Product
{
    public class ProductCardModel
    {
        public decimal RateStar { get; set; }
        public string ProductName { get; set; }
        public int Favorites { get; set; }
        public int Reviews { get; set; }
        public decimal Price { get; set; }
    }
}
