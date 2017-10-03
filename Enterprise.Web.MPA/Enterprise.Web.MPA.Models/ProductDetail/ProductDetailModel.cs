using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Web.MPA.Models.Product;

namespace Enterprise.Web.MPA.Models.ProductDetail
{
    public class ProductDetailModel:ProductCardModel
    {
        public string Location { get; set; }
        public List<string> Variations { get; set; }
        public int Stock { get; set; }
    }
}
