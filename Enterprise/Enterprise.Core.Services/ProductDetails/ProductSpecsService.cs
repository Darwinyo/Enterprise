using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.ProductDetails.Abstract;
using Enterprise.Core.Repository.ProductRepository;
using Enterprise.Core.BusinessLogics.ProductDetails;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.BusinessLogics.ProductDetails.Abstract;

namespace Enterprise.Core.Services.ProductDetails
{
    public class ProductSpecsService : IProductSpecsService
    {
        private readonly IProductSpecsBusinessLogic _productSpecsBusinessLogic;
        public ProductSpecsService(IProductSpecsBusinessLogic productSpecsBusinessLogic)
        {
            _productSpecsBusinessLogic = productSpecsBusinessLogic;
        }
        public IEnumerable<TblProductSpecs> GetAllProductSpecsByProductId(string productId)
        {
            return _productSpecsBusinessLogic.GetAllProductSpecsByProductId(productId);
        }
    }
}
