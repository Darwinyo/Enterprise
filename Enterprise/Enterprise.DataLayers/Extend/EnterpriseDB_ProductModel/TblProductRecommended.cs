using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductRecommended
    {
        public static List<TblProductRecommended> GetRecommendedProductsByPeriodeId(string PeriodeId, ProductContext context)
        {
            return context.TblProductRecommended.Where(x => x.PeriodeId == PeriodeId).ToList();
        }
    }
}
