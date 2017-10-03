using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.ProductDetails.Abstract;
using Enterprise.Core.BusinessLogics.ProductDetails;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.BusinessLogics.ProductDetails.Abstract;

namespace Enterprise.Core.Services.ProductDetails
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationBusinessLogic _productVariationBusinessLogic;
        public ProductVariationService(IProductVariationBusinessLogic productVariationBusinessLogic)
        {
            _productVariationBusinessLogic = productVariationBusinessLogic;
        }
        public IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId)
        {
            return _productVariationBusinessLogic.GetProductVariationByProductId(productId);
        }

        public void InsertNewVariations(IEnumerable<TblProductVariations> listVariation)
        {
            _productVariationBusinessLogic.InsertNewVariations(listVariation);
        }

        public int SaveVariation()
        {
            return _productVariationBusinessLogic.SaveVariation();
        }
    }
}
