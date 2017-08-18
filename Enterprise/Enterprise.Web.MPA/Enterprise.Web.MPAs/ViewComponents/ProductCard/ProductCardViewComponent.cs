using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.Product;

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
                Stars = InitStars(rateStar)
            };
            return View(productCardComponentModel);
        }
        private string[] InitStars(decimal rateStar)
        {
            string[] stars = new string[6];
            for (int i = 1; i < 6; i++)
            {
                if (rateStar >= i)
                {
                    stars[i] = "/images/icons/fullstar.png";
                }
                else if (rateStar > (i - 1))
                {
                    stars[i] = "/images/icons/halfstar.png";
                }
                else
                {
                    stars[i] = "/images/icons/nonestar.png";
                }
            }
            return stars;
        }
    }
}
