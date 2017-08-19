using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Web.MPA.Models.ProductDetail
{
    public class ProductDetailContentModel:ProductDetailModel
    {
        public string Delivery { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<string> DeliveryOptions { get; set; }
        public List<string> Locations { get; set; }
    }
}
