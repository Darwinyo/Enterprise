using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Services.ProductDetails.Abstract
{
    public interface IProductImageService
    {
        IEnumerable<TblProductImage> GetProductImageListByProductId(string productId);
    }
}
