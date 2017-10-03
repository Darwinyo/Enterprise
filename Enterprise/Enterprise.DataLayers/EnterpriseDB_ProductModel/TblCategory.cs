using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProductCategory = new HashSet<TblProductCategory>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }

        public ICollection<TblProductCategory> TblProductCategory { get; set; }
    }
}
