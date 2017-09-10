using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.Repository.ProductRepository;
using Enterprise.API.BusinessLogics.ProductDetails;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.ProductDetails
{
    public class ProductSpecsService : IProductSpecsService
    {
        private readonly ProductSpecsBusinessLogic _productSpecsBusinessLogic;
        private readonly ITblProductSpecsRepository _productSpecsRepository;
        public ProductSpecsService(ProductSpecsBusinessLogic productSpecsBusinessLogic,ITblProductSpecsRepository productSpecsRepository)
        {
            _productSpecsBusinessLogic = productSpecsBusinessLogic;
            _productSpecsRepository = productSpecsRepository;
        }
        public IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId)
        {
            return _productSpecsBusinessLogic.GetAllProductSpecsByProductId(productId, _productSpecsRepository);
        }
    }
}
