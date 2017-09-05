using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductImage
    {
        public static List<TblProductImage> GetProductImageListByProductId(string productId,ProductContext context)
        {
            return context.TblProductImage.Where(x => x.ProductId == productId).ToList();
        }
    }
}
