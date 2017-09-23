using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.ProductDetails.Abstract
{
    public interface IProductImageBusinessLogic
    {
        IEnumerable<TblProductImage> GetProductImageListByProductId(string productId);
    }
}
