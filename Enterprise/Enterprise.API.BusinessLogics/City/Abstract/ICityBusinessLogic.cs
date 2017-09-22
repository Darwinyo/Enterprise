using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.City.Abstract
{
    interface ICityBusinessLogic
    {
        IEnumerable<TblCity> GetListOfCity(ITblCityRepository cityRepository);
        string GetCityById(int cityId, ITblCityRepository cityRepository);
    }
}
