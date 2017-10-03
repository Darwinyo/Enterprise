using System.Collections.Generic;
using System.Linq;
using Enterprise.Core.BusinessLogics.City.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.City
{
    public class CityBusinessLogic : ICityBusinessLogic
    {
        private readonly ITblCityRepository _cityRepository;
        public CityBusinessLogic(ITblCityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public string GetCityById(int cityId)
        {
            return _cityRepository.FindBy(x => x.CityId == cityId).FirstOrDefault().CityName;
        }

        public IEnumerable<TblCity> GetListOfCity()
        {
            return _cityRepository.GetAll();
        }
    }
}
