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
        private readonly ITblProductHotRepository _productHotRepository;
        private readonly ITblProductRepository _productRepository;
        public HotProductBusinessLogic(ITblProductHotRepository productHotRepository, ITblProductRepository productRepository)
        {
            _productHotRepository = productHotRepository;
            _productRepository = productRepository;
        }
        public IEnumerable<TblProduct> GetHotProductsByPeriodeId(string PeriodeId)
        {
            List<TblProductHot> listRaw= _productHotRepository.FindBy(x => x.PeriodeId == PeriodeId).ToList();
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
