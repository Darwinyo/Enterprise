using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.API.BusinessLogics.Product
{
    public class RecommendedProductBusinessLogic
    {
        public static List<PM.TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId, PM.ProductContext context)
        {
            List<PM.TblProductRecommended> listRaw = PM.TblProductRecommended.GetRecommendedProductsByPeriodeId(PeriodeId, context);
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
