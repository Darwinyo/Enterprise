using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Core.BusinessLogics.Product.Abstract
{
    public interface IRecommendedProductBusinessLogic
    {
        IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId);
    }
}
