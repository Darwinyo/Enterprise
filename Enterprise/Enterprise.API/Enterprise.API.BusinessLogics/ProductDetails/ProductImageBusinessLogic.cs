using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;
namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductImageBusinessLogic
    {
        public static List<PM.TblProductImage> GetProductImageListByProductId(string productId, PM.ProductContext context)
        {
            if (productId != string.Empty || productId != null)
                return PM.TblProductImage.GetProductImageListByProductId(productId, context);
            return null;
        }
    }
}
