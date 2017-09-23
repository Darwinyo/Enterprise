using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.ProductDetails.Abstract
{
    public interface IProductVariationBusinessLogic
    {
        void InsertNewVariations(IEnumerable<TblProductVariations> listVariation);
        IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId);
        int SaveVariation();
    }
}
