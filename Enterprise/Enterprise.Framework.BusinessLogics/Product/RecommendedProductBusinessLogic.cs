using System.Collections.Generic;
using System.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.BusinessLogics.Product.Abstract;

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
        public IEnumerable<Tbl_Product> GetRecommendedProductsByPeriodeId(string PeriodeId)
        {
            List<Tbl_Product_Recommended> listRaw = _productRecommendedRepository.FindBy(x => x.Periode_Id == PeriodeId).ToList();
            if (listRaw.Count() > 0)
            {
                List<string> list = new List<string>();
                listRaw.ForEach(x => list.Add(x.Product_Id));
                return _productRepository.GetListProductByListString(list);
            }
            return null;
        }
    }
}
