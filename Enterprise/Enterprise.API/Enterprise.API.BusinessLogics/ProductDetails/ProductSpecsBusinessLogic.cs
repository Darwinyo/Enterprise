using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductSpecsBusinessLogic
    {
        public static List<PM.TblProductSpecs> GetAllProductSpecsByProductId(string productId, PM.ProductContext context)
        {
            if (productId != null)
                return PM.TblProductSpecs.GetAllProductSpecsByProductId(productId, context);
            return null;
        }
    }
}
