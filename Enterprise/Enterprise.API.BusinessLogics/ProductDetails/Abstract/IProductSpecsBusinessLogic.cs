using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using Enterprise.Repository.ProductRepository;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.ProductDetails.Abstract
{
    public interface IProductSpecsBusinessLogic
    {
        IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId);
    }
}
