using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Core.Services.ProductDetails.Abstract
{
    public interface IProductImageService
    {
        IEnumerable<TblProductImage> GetProductImageListByProductId(string productId);
    }
}
