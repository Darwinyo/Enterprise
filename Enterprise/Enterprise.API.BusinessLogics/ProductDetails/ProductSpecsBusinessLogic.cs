using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using System.Linq;
using Enterprise.Core.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.ProductDetails
{
    public class ProductSpecsBusinessLogic:IProductSpecsBusinessLogic
    {
        private readonly ITblProductSpecsRepository _productSpecsRepository;
        public ProductSpecsBusinessLogic(ITblProductSpecsRepository productSpecsRepository)
        {
            _productSpecsRepository = productSpecsRepository;
        }
        public IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId)
        {
            if (productId != null)
                return _productSpecsRepository.FindBy(x => x.ProductId == productId).AsEnumerable();
            return null;
        }
    }
}
