using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.ProductDetail;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.ProductInfoDescription
{
    public class ProductInfoDescriptionViewComponent : ViewComponent
    {
        public ProductInfoDescriptionViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(string description,List<ProductItemSpecsModel> listSpecs)
        {
            ProductDetailDescriptionComponentModel productDetailDescriptionComponent = new ProductDetailDescriptionComponentModel()
            {
                DetailsProduct = listSpecs,
                Description = description
            };
            return View(productDetailDescriptionComponent);
        }
    }
}
