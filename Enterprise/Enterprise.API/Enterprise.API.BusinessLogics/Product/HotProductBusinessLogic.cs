using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.API.BusinessLogics.Product
{
    public class HotProductBusinessLogic
    {
        public static List<PM.TblProduct> GetHotProductsByPeriodeId(string PeriodeId, PM.ProductContext context)
        {
            List<PM.TblProductHot> listRaw = PM.TblProductHot.GetHotProductsByPeriodeId(PeriodeId, context);
            if (listRaw.Count > 0)
            {
                List<string> list = new List<string>();
                listRaw.ForEach(x => list.Add(x.ProductId));
                return PM.TblProduct.GetListProductByListString(list, context);
            }
            return null;
        }
    }
}
