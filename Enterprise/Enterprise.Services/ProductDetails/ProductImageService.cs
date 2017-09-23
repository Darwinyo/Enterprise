using System.Collections.Generic;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;

namespace Enterprise.Services.ProductDetails
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
