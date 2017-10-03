using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.Product;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.GridProduct
{
    public class GridProductViewComponent : ViewComponent
    {
        public GridProductViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(List<ProductCardModel> productList)
        {
            return View(productList);
        }
    }
}
