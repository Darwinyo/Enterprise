using System;
using System.Collections.Generic;
using System.Text;
using HM = Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Newtonsoft.Json.Linq;
namespace Enterprise.API.BusinessLogics.Periode
{
    public class PeriodeBusinessLogic
    {
        public static bool CreatePeriode(object obj, HM.HelperContext context)
        {
            if (obj != null)
            {
                JObject jObject = (JObject)obj;
                HM.TblPeriode tblPeriode = new HM.TblPeriode
                {
                    PeriodeId=Guid.NewGuid().ToString(),
                    PeriodeDescription = jObject["periodeDescription"].ToString(),
                    PeriodeEndDate = jObject["periodeEndDate"].ToObject<DateTime>(),
                    PeriodeStartDate = jObject["periodeStartDate"].ToObject<DateTime>()
                };
                if (HM.TblPeriode.CreatePeriode(tblPeriode, context) != 0)
                    return true;
                return false;
            }
            return false;
        }
        public static string GetPeriodeId(string dateTime, HM.HelperContext context)
        {
            DateTime date;
            if (DateTime.TryParse(dateTime, out date))
                return HM.TblPeriode.GetPeriodeId(date, context);
            return null;
        }
    }
}
