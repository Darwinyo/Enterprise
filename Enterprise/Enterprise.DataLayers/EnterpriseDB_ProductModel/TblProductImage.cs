using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductImage
    {
        public string PImageId { get; set; }
        public string ProductId { get; set; }
        public byte[] ProductImage { get; set; }

        public TblProduct Product { get; set; }
    }
}
