using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.City.Abstract
{
    public interface ICityBusinessLogic
    {
        IEnumerable<TblCity> GetListOfCity();
        string GetCityById(int cityId);
    }
}
