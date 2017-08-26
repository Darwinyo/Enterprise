using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductCategory
    {
        public string PCategoryId { get; set; }
        public string CategoryId { get; set; }
        public string ProductId { get; set; }

        public TblCategory Category { get; set; }
        public TblProduct Product { get; set; }
    }
}
