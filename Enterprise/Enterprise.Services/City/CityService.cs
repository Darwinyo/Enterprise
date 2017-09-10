using System.Collections.Generic;
using Enterprise.Services.City.Abstract;
using Enterprise.API.BusinessLogics.City;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.City
{
    public class CityService : ICityService
    {
        private readonly CityBusinessLogic _cityBusinessLogic;
        private readonly ITblCityRepository _cityRepository;
        public CityService(ITblCityRepository cityRepository)
        {
            _cityBusinessLogic = new CityBusinessLogic();
            _cityRepository = cityRepository;
        }
        public string GetCityById(int cityId)
        {
            return _cityBusinessLogic.GetCityById(cityId, _cityRepository);
        }

        public IEnumerable<TblCity> GetListOfCity()
        {
            return _cityBusinessLogic.GetListOfCity(_cityRepository);
        }
    }
}
