using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Linq;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.ProductDetails
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
