using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using System.Collections.Generic;

namespace Enterprise.Core.Services.City.Abstract
{
    public interface ICityService
    {
        IEnumerable<TblCity> GetListOfCity();
        string GetCityById(int cityId);
    }
}
