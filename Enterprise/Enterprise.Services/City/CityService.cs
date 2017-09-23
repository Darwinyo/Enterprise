using System.Collections.Generic;
using Enterprise.Services.City.Abstract;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.API.BusinessLogics.City.Abstract;

namespace Enterprise.Services.City
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
