using System;
using Newtonsoft.Json.Linq;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.API.BusinessLogics.Periode.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Periode
{
    public class PeriodeBusinessLogic:IPeriodeBusinessLogic
    {
        private readonly ITblPeriodeRepository _periodeRepository;
        public PeriodeBusinessLogic(ITblPeriodeRepository periodeRepository)
        {
            _periodeRepository = periodeRepository;
        }
        public TblPeriode CreatePeriode(object obj)
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
        public void InsertPeriode(object obj)
        {
            TblPeriode periode = CreatePeriode(obj);
            if (periode != null)
            {
                _periodeRepository.Add(periode);
            }
        }
        public int SavePeriode()
        {
            return _periodeRepository.Commit();
        }
        public string GetPeriodeId(string dateTime)
        {
            DateTime date;
            if (DateTime.TryParse(dateTime, out date))
                return _periodeRepository.GetSingle(x => x.PeriodeStartDate < date && x.PeriodeEndDate > date).PeriodeId;
            return null;
        }
    }
}
