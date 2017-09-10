using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Linq;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductSpecsBusinessLogic:IProductSpecsBusinessLogic
    {
        public IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId, ITblProductSpecsRepository productSpecsRepository)
        {
            if (productId != null)
                return productSpecsRepository.FindBy(x => x.ProductId == productId).AsEnumerable();
            return null;
        }
    }
}
