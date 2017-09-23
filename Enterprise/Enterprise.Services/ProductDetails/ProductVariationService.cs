using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.API.BusinessLogics.ProductDetails;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;

namespace Enterprise.Services.ProductDetails
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
