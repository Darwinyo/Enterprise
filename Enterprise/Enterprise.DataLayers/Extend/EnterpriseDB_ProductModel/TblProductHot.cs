using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductHot
    {
        public static List<TblProductHot> GetHotProductsByPeriodeId(string PeriodeId, ProductContext context)
        {
            return context.TblProductHot.Where(x => x.PeriodeId == PeriodeId).ToList();
        }
    }
}
