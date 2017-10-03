using System.Collections.Generic;
using Enterprise.Core.Services.ProductDetails.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.BusinessLogics.ProductDetails.Abstract;

namespace Enterprise.Core.Services.ProductDetails
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageBusinessLogic _productImageBusinessLogic;
        public ProductImageService(IProductImageBusinessLogic productImageBusinessLogic)
        {
            _productImageBusinessLogic = productImageBusinessLogic;
        }
        public IEnumerable<TblProductImage> GetProductImageListByProductId(string productId)
        {
            return _productImageBusinessLogic.GetProductImageListByProductId(productId);
        }
    }
}
