using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.DataLayers.Models;

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
