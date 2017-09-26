using System.Collections.Generic;
using System.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.Repository.ProductRepository;
using Enterprise.Framework.DataLayers.DTOs.Product;

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
        public IEnumerable<ProductCardDTO> GetHotProductsByPeriodeId(string PeriodeId)
        {
            List<TblProductHot> listRaw= _productHotRepository.FindBy(x => x.PeriodeId == PeriodeId).ToList();
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
