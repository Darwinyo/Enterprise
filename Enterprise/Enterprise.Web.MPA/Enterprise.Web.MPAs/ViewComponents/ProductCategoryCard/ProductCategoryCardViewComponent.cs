using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.ProductCategoryCard
{
    public class ProductCategoryCardViewComponent : ViewComponent
    {
        public ProductCategoryCardViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(string productName)
        {
            return View(productName);
        }
    }
}
