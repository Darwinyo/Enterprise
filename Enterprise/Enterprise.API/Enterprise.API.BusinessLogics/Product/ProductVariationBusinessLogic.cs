using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enterprise.API.BusinessLogics.Product
{
    public class ProductVariationBusinessLogic
    {
        public static int InsertNewVariations(List<TblProductVariations> listVariation, ProductContext context)
        {
            if (listVariation != null)
                return 0;
            return TblProductVariations.InsertNewVariations(listVariation, context);
        }
    }
}
