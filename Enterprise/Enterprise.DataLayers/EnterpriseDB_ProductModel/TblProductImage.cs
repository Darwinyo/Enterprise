using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductImage
    {
        public string PImageId { get; set; }
        public string ProductId { get; set; }
        public byte[] ProductImageUrl { get; set; }
        public string ProductImageName { get; set; }
        public int ProductImageSize { get; set; }

        public TblProduct Product { get; set; }
    }
}
