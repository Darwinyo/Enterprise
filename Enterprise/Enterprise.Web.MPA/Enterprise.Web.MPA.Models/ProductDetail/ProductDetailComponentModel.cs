using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Web.MPA.Models.ProductDetail
{
    public class ProductDetailComponentModel:ProductDetailModel
    {
        public string[] Stars { get; set; }
        public string Deliver { get; set; }
        public decimal DeliverPrice { get; set; }
        public int Quantity { get; set; }
        public List<string> Locations { get; set; }
        public List<string> DeliveryOptions { get; set; }
    }
}
