using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;

namespace Enterprise.Services.Product
{
    public class HotProductService : IHotProductService
    {
        private readonly IHotProductBusinessLogic _hotProductBusinessLogic;
        public HotProductService(IHotProductBusinessLogic hotProductBusinessLogic)
        {
            _hotProductBusinessLogic = hotProductBusinessLogic;
        }
        public IEnumerable<TblProduct> GetHotProductsByPeriodeId(string PeriodeId)
        {
            return _hotProductBusinessLogic.GetHotProductsByPeriodeId(PeriodeId);
        }
    }
}
