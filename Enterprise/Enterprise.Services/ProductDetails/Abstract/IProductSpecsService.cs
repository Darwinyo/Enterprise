using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Services.ProductDetails.Abstract
{
    public interface IProductSpecsService
    {
        IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId);
    }
}
