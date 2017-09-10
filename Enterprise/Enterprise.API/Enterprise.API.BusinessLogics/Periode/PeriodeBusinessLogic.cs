using System;
using Newtonsoft.Json.Linq;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.API.BusinessLogics.Periode.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Periode
{
    public class PeriodeBusinessLogic:IPeriodeBusinessLogic
    {
        public TblPeriode CreatePeriode(object obj, ITblPeriodeRepository periodeRepository)
        {
            if (obj != null)
            {
                JObject jObject = (JObject)obj;
                TblPeriode tblPeriode = new TblPeriode
                {
                    PeriodeId=Guid.NewGuid().ToString(),
                    PeriodeDescription = jObject["periodeDescription"].ToString(),
                    PeriodeEndDate = jObject["periodeEndDate"].ToObject<DateTime>(),
                    PeriodeStartDate = jObject["periodeStartDate"].ToObject<DateTime>()
                };
                return tblPeriode;
            }
            return null;
        }
        public void InsertPeriode(object obj, ITblPeriodeRepository periodeRepository)
        {
            TblPeriode periode = CreatePeriode(obj,periodeRepository);
            if (periode != null)
            {
                periodeRepository.Add(periode);
            }
        }
        public int SavePeriode(ITblPeriodeRepository periodeRepository)
        {
            return periodeRepository.Commit();
        }
        public string GetPeriodeId(string dateTime, ITblPeriodeRepository periodeRepository)
        {
            DateTime date;
            if (DateTime.TryParse(dateTime, out date))
                return periodeRepository.GetSingle(x => x.PeriodeStartDate < date && x.PeriodeEndDate > date).PeriodeId;
            return null;
        }
    }
}
