using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductImage
    {
        public string PImageId { get; set; }
        public string ProductId { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductImageName { get; set; }
        public int ProductImageSize { get; set; }

        public TblProduct Product { get; set; }
    }
}
