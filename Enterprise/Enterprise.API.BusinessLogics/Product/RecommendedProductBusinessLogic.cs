using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.ProductRepository;
using System.Collections.Generic;
using System.Linq;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.Product
{
    public class RecommendedProductBusinessLogic:IRecommendedProductBusinessLogic
    {
        private readonly ITblProductRecommendedRepository _productRecommendedRepository;
        private readonly ITblProductRepository _productRepository;
        public RecommendedProductBusinessLogic(ITblProductRecommendedRepository productRecommendedRepository, ITblProductRepository productRepository)
        {
            _productRecommendedRepository = productRecommendedRepository;
            _productRepository = productRepository;
        }
        public IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId)
        {
            List<TblProductRecommended> listRaw = _productRecommendedRepository.FindBy(x => x.PeriodeId == PeriodeId).ToList();
            if (listRaw.Count() > 0)
            {
                List<string> list = new List<string>();
                listRaw.ForEach(x => list.Add(x.ProductId));
                return _productRepository.GetListProductByListString(list);
            }
            return null;
        }
    }
}
