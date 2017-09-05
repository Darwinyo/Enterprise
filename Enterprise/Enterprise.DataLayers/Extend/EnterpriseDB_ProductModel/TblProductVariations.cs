using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductVariations
    {
        public static int InsertNewVariations(List<TblProductVariations> listVariation,ProductContext context)
        {
            context.TblProductVariations.AddRange(listVariation);
            return context.SaveChanges();
        }
        public static List<TblProductVariations> GetProductVariationByProductId(string productId,ProductContext context)
        {
            return context.TblProductVariations.Where(x=>x.ProductId==productId).ToList();
        }
    }
}
