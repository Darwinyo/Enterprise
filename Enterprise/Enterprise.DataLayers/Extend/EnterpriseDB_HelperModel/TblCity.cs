using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_HelperModel
{
    public partial class TblCity
    {
        public static List<TblCity> GetListOfCity(HelperContext context)
        {
            return context.TblCity.Where(x=>x.CountryId==2).ToList();
        }
        public static string GetCityById(int cityId,HelperContext context)
        {
            return context.TblCity.Where(x => x.CityId == cityId).FirstOrDefault().CityName;
        }
    }
}
