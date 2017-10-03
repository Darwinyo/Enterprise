using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.Repository.ProductRepository;
using System.Collections.Generic;

namespace Enterprise.Core.BusinessLogics.ProductDetails.Abstract
{
    public interface IProductSpecsBusinessLogic
    {
        IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId);
    }
}
