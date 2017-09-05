using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductSpecs
    {
        public static List<TblProductSpecs> GetAllProductSpecsByProductId(string productId,ProductContext context)
        {
            return context.TblProductSpecs.Where(x => x.ProductId == productId).ToList();
        }
    }
}
