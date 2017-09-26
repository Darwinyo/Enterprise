using System.Collections.Generic;
using System.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.DataLayers.DTOs.Product;

namespace Enterprise.Framework.BusinessLogics.Product
{
    public class RecommendedProductBusinessLogic:IRecommendedProductBusinessLogic
    {
        private readonly ITblProductRecommendedRepository _productRecommendedRepository;
        private readonly ITblProductRepository _productRepository;
        public RecommendedProductBusinessLogic(ITblProductRecommendedRepository productRecommendedRepository,ITblProductRepository productRepository)
        {
            _productRecommendedRepository = productRecommendedRepository;
            _productRepository = productRepository;
        }
        public IEnumerable<ProductCardDTO> GetRecommendedProductsByPeriodeId(string PeriodeId)
        {
            List<TblProductRecommended> listRaw = _productRecommendedRepository.FindBy(x => x.PeriodeId == PeriodeId).ToList();
            if (listRaw.Count() > 0)
            {
                List<string> list = new List<string>();
                listRaw.ForEach(x => list.Add(x.ProductId));
                return _productRepository.GetListProductCardByListString(list);
            }
            return null;
        }
    }
}
