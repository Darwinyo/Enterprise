using System.Collections.Generic;
using System.Linq;
using Enterprise.API.BusinessLogics.City.Abstract;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.City
{
    public class CityBusinessLogic : ICityBusinessLogic
    {
        public string GetCityById(int cityId, ITblCityRepository cityRepository)
        {
            return cityRepository.FindBy(x => x.CityId == cityId).FirstOrDefault().CityName;
        }

        public IEnumerable<TblCity> GetListOfCity(ITblCityRepository cityRepository)
        {
            return cityRepository.GetAll();
        }
    }
}
