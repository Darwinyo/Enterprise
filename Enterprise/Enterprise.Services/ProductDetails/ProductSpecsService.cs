using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.Repository.ProductRepository;
using Enterprise.API.BusinessLogics.ProductDetails;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;

namespace Enterprise.Services.ProductDetails
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
