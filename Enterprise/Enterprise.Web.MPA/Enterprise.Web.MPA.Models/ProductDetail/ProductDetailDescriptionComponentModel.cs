using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Web.MPA.Models.ProductDetail
{
    public class ProductDetailDescriptionComponentModel
    {
        public string Description { get; set; }
        public List<ProductItemSpecsModel> DetailsProduct { get; set; }
    }
}
