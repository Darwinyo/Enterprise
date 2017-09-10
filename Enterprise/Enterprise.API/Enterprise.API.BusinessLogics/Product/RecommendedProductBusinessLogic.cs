using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.ProductRepository;
using System.Collections.Generic;
using System.Linq;
using Enterprise.API.BusinessLogics.Product.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product
{
    public class RecommendedProductBusinessLogic:IRecommendedProductBusinessLogic
    {
        public IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId, ITblProductRecommendedRepository productRecommendedRepository, ProductContext context)
        {
            List<TblProductRecommended> listRaw = productRecommendedRepository.FindBy(x => x.PeriodeId == PeriodeId).ToList();
            if (listRaw.Count() > 0)
            {
                List<string> list = new List<string>();
                listRaw.ForEach(x => list.Add(x.ProductId));
                TblProductRepository productRepository = new TblProductRepository(context);
                return productRepository.GetListProductByListString(list);
            }
            return null;
        }
    }
}
