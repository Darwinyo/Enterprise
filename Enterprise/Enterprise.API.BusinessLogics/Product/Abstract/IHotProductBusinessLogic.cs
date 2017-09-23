using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.Product.Abstract
{
    public interface IHotProductBusinessLogic
    {
        IEnumerable<TblProduct> GetHotProductsByPeriodeId(string PeriodeId);
    }
}
