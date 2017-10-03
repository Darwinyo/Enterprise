using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;
using Enterprise.Framework.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface IRecommendedProductBusinessLogic
    {
        IEnumerable<ProductCardDTO> GetRecommendedProductsByPeriodeId(string PeriodeId);
    }
}
