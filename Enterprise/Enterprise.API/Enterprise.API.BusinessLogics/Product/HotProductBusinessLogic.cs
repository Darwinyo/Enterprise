using System.Collections.Generic;
using System.Linq;
using Enterprise.API.BusinessLogics.Product.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.ProductRepository;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product
{
    public class HotProductBusinessLogic:IHotProductBusinessLogic
    {
        public IEnumerable<TblProduct> GetHotProductsByPeriodeId(string PeriodeId, ITblProductHotRepository hotRepository,ProductContext context)
        {
            List<TblProductHot> listRaw= hotRepository.FindBy(x => x.PeriodeId == PeriodeId).ToList();
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
