using System;
using Newtonsoft.Json.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;
using Enterprise.Framework.Repository.Abstract;

namespace Enterprise.Framework.BusinessLogics.Periode
{
    public class PeriodeBusinessLogic:IPeriodeBusinessLogic
    {
        private readonly ITblPeriodeRepository _periodeRepository;
        public PeriodeBusinessLogic(ITblPeriodeRepository periodeRepository)
        {
            _periodeRepository = periodeRepository;
        }
        public Tbl_Periode CreatePeriode(object obj)
        {
            if (obj != null)
            {
                JObject jObject = (JObject)obj;
                Tbl_Periode tblPeriode = new Tbl_Periode
                {
                    Periode_Id=Guid.NewGuid().ToString(),
                    Periode_Description = jObject["periodeDescription"].ToString(),
                    Periode_EndDate = jObject["periodeEndDate"].ToObject<DateTime>(),
                    Periode_StartDate = jObject["periodeStartDate"].ToObject<DateTime>()
                };
                return tblPeriode;
            }
            return null;
        }
        public void InsertPeriode(Tbl_Periode periode)
        {
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
                return _periodeRepository.GetSingle(x => x.Periode_StartDate < date && x.Periode_EndDate > date).Periode_Id;
            return null;
        }
    }
}
