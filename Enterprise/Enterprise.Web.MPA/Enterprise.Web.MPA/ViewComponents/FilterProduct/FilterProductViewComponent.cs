using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Web.MPA.Models.Filter;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.Web.MPA.ViewComponents.FilterProduct
{
    public class FilterProductViewComponent : ViewComponent
    {
        public FilterProductViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(List<FilterProductModel> filterProductList)
        {
            return View(filterProductList);
        }
    }
}
