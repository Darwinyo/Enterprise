using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.DataLayers.Models
{
    public class HotProductModel
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal RateStar { get; set; }
        public int Favorites { get; set; }
        public int Reviews { get; set; }
    }
}
