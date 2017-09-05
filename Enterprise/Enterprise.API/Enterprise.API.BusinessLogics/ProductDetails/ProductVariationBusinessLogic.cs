using System;
using System.Collections.Generic;
using System.Text;
using PM= Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductVariationBusinessLogic
    {
        public static int InsertNewVariations(List<PM.TblProductVariations> listVariation, PM.ProductContext context)
        {
            if (listVariation != null)
                return 0;
            return PM.TblProductVariations.InsertNewVariations(listVariation, context);
        }
        public static List<PM.TblProductVariations> GetProductVariationByProductId(string productId, PM.ProductContext context)
        {
            return PM.TblProductVariations.GetProductVariationByProductId(productId, context);
        }
    }
}
