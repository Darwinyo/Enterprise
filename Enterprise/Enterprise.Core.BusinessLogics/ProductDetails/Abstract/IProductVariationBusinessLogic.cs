using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Core.BusinessLogics.ProductDetails.Abstract
{
    public interface IProductVariationBusinessLogic
    {
        void InsertNewVariations(IEnumerable<TblProductVariations> listVariation);
        IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId);
        int SaveVariation();
    }
}
