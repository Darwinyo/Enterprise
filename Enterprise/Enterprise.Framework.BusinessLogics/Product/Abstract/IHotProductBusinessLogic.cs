using Enterprise.Framework.DataLayers;
using System.Collections.Generic;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface IHotProductBusinessLogic
    {
        IEnumerable<Tbl_Product> GetHotProductsByPeriodeId(string PeriodeId);
    }
}
