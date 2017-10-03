using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Core.Services.ProductDetails.Abstract
{
    public interface IProductSpecsService
    {
        IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId);
    }
}
