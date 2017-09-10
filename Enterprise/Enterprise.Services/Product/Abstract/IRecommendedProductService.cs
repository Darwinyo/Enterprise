using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Services.Product.Abstract
{
    public interface IRecommendedProductService
    {
        IEnumerable<TblProduct> GetRecommendedProductsByPeriodeId(string PeriodeId);
    }
}
