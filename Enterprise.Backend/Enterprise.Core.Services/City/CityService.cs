using System.Collections.Generic;
using Enterprise.Core.Services.City.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Core.BusinessLogics.City.Abstract;

namespace Enterprise.Core.Services.City
{
    public class CityService : ICityService
    {
        private readonly ICityBusinessLogic _cityBusinessLogic;
        public CityService(ICityBusinessLogic cityBusinessLogic)
        {
            _cityBusinessLogic = cityBusinessLogic;
        }
        public string GetCityById(int cityId)
        {
            return _cityBusinessLogic.GetCityById(cityId);
        }

        public IEnumerable<TblCity> GetListOfCity()
        {
            return _cityBusinessLogic.GetListOfCity();
        }
    }
}
