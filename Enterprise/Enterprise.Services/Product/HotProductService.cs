using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.Product
{
    public class HotProductService : IHotProductService
    {
        private readonly HotProductBusinessLogic _hotProductBusinessLogic;
        private readonly ITblProductHotRepository _productHotRepository;
        private readonly ProductContext _context;
        public HotProductService(HotProductBusinessLogic hotProductBusinessLogic,ITblProductHotRepository productHotRepository,ProductContext context)
        {
            _hotProductBusinessLogic = hotProductBusinessLogic;
            _productHotRepository = productHotRepository;
            _context = context;
        }
        public IEnumerable<TblProduct> GetHotProductsByPeriodeId(string PeriodeId)
        {
            return _hotProductBusinessLogic.GetHotProductsByPeriodeId(PeriodeId, _productHotRepository, _context);
        }
    }
}
