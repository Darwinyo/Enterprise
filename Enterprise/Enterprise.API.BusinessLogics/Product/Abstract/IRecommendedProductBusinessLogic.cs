using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.Product.Abstract
{
    public interface IRecommendedProductBusinessLogic
    {
        IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId);
    }
}
