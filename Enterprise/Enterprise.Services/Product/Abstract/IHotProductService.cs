using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Services.Product.Abstract
{
    public interface IHotProductService
    {
        IEnumerable<TblProduct> GetHotProductsByPeriodeId(string PeriodeId);
    }
}
