using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.ProductDetail;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.ProductInfoDetails
{
    public class ProductInfoDetailsViewComponent : ViewComponent
    {
        public ProductInfoDetailsViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(
            string productTitle,
            decimal productPrice,
            decimal ratestar,
            int reviews,
            int favorites,
            string location,
            List<string> variations,
            int stock,
            string deliver,
            decimal deliverPrice,
            List<string> locations,
            List<string> deliveryOptions)
        {
            ProductDetailComponentModel ProductDetailComponent = new ProductDetailComponentModel()
            {
                ProductName = productTitle,
                Price = productPrice,
                Favorites = favorites,
                Location = location,
                RateStar = ratestar,
                Reviews = reviews,
                Stock = stock,
                Variations = variations,
                Deliver = deliver,
                DeliverPrice = deliverPrice,
                Quantity = 1,
                Locations = locations,
                DeliveryOptions = deliveryOptions,
            };
            return View(ProductDetailComponent);
        }
    }
}
