using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HM= Enterprise.DataLayers.EnterpriseDB_HelperModel;
namespace Enterprise.API.BusinessLogics.City
{
    public class CityBusinessLogic
    {
        public static List<HM.TblCity> GetListOfCity(HM.HelperContext context)
        {
            return HM.TblCity.GetListOfCity(context);
        }
    }
}
