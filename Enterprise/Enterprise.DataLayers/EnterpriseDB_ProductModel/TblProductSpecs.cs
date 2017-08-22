using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductSpecs
    {
        public string PSpecId { get; set; }
        public string ProductId { get; set; }
        public string ProductSpecTitle { get; set; }
        public string ProductSpecValue { get; set; }

        public TblProduct Product { get; set; }
    }
}
