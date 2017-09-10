using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Services.ProductDetails.Abstract
{
    public interface IProductVariationService
    {
        void InsertNewVariations(IEnumerable<TblProductVariations> listVariation);
        IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId);
        int SaveVariation();
    }
}
