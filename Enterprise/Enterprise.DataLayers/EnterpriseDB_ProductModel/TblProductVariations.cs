using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductVariations
    {
        public string PVariationId { get; set; }
        public string ProductId { get; set; }
        public string ProductVariation { get; set; }

        public TblProduct Product { get; set; }
    }
}
