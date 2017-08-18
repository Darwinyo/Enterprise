using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Web.MPA.Models.Filter
{
    public class FilterProductModel
    {
        public string Category { get; set; }
        public List<FilterModel> FilterLists { get; set; }
    }
}
