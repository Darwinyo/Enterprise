using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;

namespace Enterprise.Services.Product
{
    public class RecommendedProductService : IRecommendedProductService
    {
        private readonly IRecommendedProductBusinessLogic _recommendedProductBusinessLogic;
        public RecommendedProductService(IRecommendedProductBusinessLogic recommendedProductBusinessLogic)
        {
            _recommendedProductBusinessLogic = recommendedProductBusinessLogic;
        }
        public IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId)
        {
            return _recommendedProductBusinessLogic.GetRecommendedProductsByPeriodeId(PeriodeId);
        }
    }
}
