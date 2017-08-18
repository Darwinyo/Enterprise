using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Enterprise.Web.MPA.Pages.Product
{
    public class IndexModel : PageModel
    {
        public int ID { get; set; }
        public void OnGet()
        {
            ID = 0;
        }
    }
}