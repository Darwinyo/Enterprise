using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.City.Abstract
{
    public interface ICityBusinessLogic
    {
        IEnumerable<TblCity> GetListOfCity();
        string GetCityById(int cityId);
    }
}
