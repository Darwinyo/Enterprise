using System.Collections.Generic;
using Enterprise.API.BusinessLogics.ProductDetails;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.ProductDetails
{
    public class ProductImageService : IProductImageService
    {
        private readonly ProductImageBusinessLogic _productImageBusinessLogic;
        private readonly ITblProductImageRepository _productImageRepository;
        public ProductImageService(ProductImageBusinessLogic productImageBusinessLogic,ITblProductImageRepository productImageRepository)
        {
            _productImageBusinessLogic = productImageBusinessLogic;
            _productImageRepository = productImageRepository;
        }
        public IEnumerable<TblProductImage> GetProductImageListByProductId(string productId)
        {
            return _productImageBusinessLogic.GetProductImageListByProductId(productId, _productImageRepository);
        }
    }
}
