using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Enterprise.Web.MPA.Models.ProductDetail;
using Enterprise.Web.MPA.BusinessLogics.StarRate;

namespace Enterprise.Web.MPA.Pages.ProductDetails
{
    public class IndexModel : PageModel
    {
        public ProductDetailModel productDetail { get; set; }
        public void OnGet()
        {
        }
        ProductDetailModel FetchData()
        {

        }
    }
}