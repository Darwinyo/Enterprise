using System.Collections.Generic;
using System.Linq;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductImageBusinessLogic:IProductImageBusinessLogic
    {
        private readonly ITblProductImageRepository _productImageRepository;
        public ProductImageBusinessLogic(ITblProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public IEnumerable<TblProductImage> GetProductImageListByProductId(string productId)
        {
            if (productId != string.Empty || productId != null)
                return _productImageRepository.FindBy(x => x.ProductId == productId).AsEnumerable();
            return null;
        }
    }
}
