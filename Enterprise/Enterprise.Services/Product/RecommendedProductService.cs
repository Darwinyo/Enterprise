using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.Product
{
    public class RecommendedProductService : IRecommendedProductService
    {
        private readonly ITblProductRecommendedRepository _productRecommendedRepository;
        private readonly RecommendedProductBusinessLogic _recommendedProductBusinessLogic;
        private readonly ProductContext _context;
        public RecommendedProductService(ITblProductRecommendedRepository productRecommendedRepository,ProductContext context)
        {
            _productRecommendedRepository = productRecommendedRepository;
            _recommendedProductBusinessLogic = new RecommendedProductBusinessLogic();
            _context = context;
        }
        public IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId)
        {
            return _recommendedProductBusinessLogic.GetRecommendedProductsByPeriodeId(PeriodeId, _productRecommendedRepository, _context);
        }
    }
}
