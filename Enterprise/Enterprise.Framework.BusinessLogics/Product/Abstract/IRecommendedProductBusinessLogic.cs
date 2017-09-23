using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface IRecommendedProductBusinessLogic
    {
        IEnumerable<Tbl_Product> GetRecommendedProductsByPeriodeId(string PeriodeId);
    }
}
