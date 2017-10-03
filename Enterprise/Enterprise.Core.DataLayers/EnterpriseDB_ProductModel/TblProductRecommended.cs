using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductRecommended
    {
        public string PRecommendId { get; set; }
        public string PeriodeId { get; set; }
        public string ProductId { get; set; }

        public TblProduct Product { get; set; }
    }
}
