using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Mobile.Models.Product
{
    public class ProductCardModel
    {
        public decimal StarRate { get; set; }
        public string ProductName { get; set; }
        public int Favorites { get; set; }
        public int Reviews { get; set; }
        public decimal Price { get; set; }
    }
}
