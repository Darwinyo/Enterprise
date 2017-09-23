using System.Collections.Generic;
using System.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.Repository.ProductRepository;

namespace Enterprise.Framework.BusinessLogics.Product
{
    public class HotProductBusinessLogic:IHotProductBusinessLogic
    {
        private readonly ITblProductHotRepository _productHotRepository;
        private readonly ITblProductRepository _productRepository;
        public HotProductBusinessLogic(ITblProductHotRepository productHotRepository,ITblProductRepository productRepository)
        {
            _productHotRepository = productHotRepository;
            _productRepository = productRepository;
        }
        public IEnumerable<Tbl_Product> GetHotProductsByPeriodeId(string PeriodeId)
        {
            List<Tbl_Product_Hot> listRaw= _productHotRepository.FindBy(x => x.Periode_Id == PeriodeId).ToList();
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
