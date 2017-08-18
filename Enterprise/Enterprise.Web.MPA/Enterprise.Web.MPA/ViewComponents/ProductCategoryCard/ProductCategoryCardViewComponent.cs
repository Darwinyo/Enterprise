using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.Product;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.ProductCategoryCard
{
    public class ProductCategoryCardViewComponent : ViewComponent
    {
        public ProductCategoryCardViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(ProductCategoryCardModel categoryName)
        {
            return View(categoryName);
        }
    }
}
