using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;
using System.Collections.Generic;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface IHotProductBusinessLogic
    {
        IEnumerable<ProductCardDTO> GetHotProductsByPeriodeId(string PeriodeId);
    }
}
