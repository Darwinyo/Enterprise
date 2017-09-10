using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.API.BusinessLogics.ProductDetails;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.ProductDetails
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly ProductVariationBusinessLogic _productVariationBusinessLogic;
        private readonly ITblProductVariationsRepository _productVariationsRepository;
        public ProductVariationService(ProductVariationBusinessLogic productVariationBusinessLogic, ITblProductVariationsRepository productVariationsRepository)
        {
            _productVariationBusinessLogic = productVariationBusinessLogic;
            _productVariationsRepository = productVariationsRepository;
        }
        public IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId)
        {
            return _productVariationBusinessLogic.GetProductVariationByProductId(productId, _productVariationsRepository);
        }

        public void InsertNewVariations(IEnumerable<TblProductVariations> listVariation)
        {
            _productVariationBusinessLogic.InsertNewVariations(listVariation, _productVariationsRepository);
        }

        public int SaveVariation()
        {
            return _productVariationBusinessLogic.SaveVariation(_productVariationsRepository);
        }
    }
}
