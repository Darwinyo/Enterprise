using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.Product;
using Enterprise.Web.MPA.BusinessLogics.StarRate;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.ProductCard
{
    public class ProductCardViewComponent : ViewComponent
    {
        public ProductCardViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(
            string productName,
            decimal price,
            decimal rateStar,
            int favorites,
            int reviews)
        {

            ProductCardComponentModel productCardComponentModel = new ProductCardComponentModel
            {
                ProductName = productName,
                Price = price,
                RateStar = rateStar,
                Favorites = favorites,
                Reviews = reviews,
                Stars = StarRateBusinessLogic.InitStars(rateStar)
            };
            return View(productCardComponentModel);
        }
    }
}
