using Enterprise.Services.Periode.Abstract;
using Enterprise.API.BusinessLogics.Periode;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.Periode.Abstract;

namespace Enterprise.Services.Periode
{
    public class PeriodeService : IPeriodeService
    {
        private readonly IPeriodeBusinessLogic _periodeBusinessLogic;
        public PeriodeService(IPeriodeBusinessLogic periodeBusinessLogic)
        {
            _periodeBusinessLogic = periodeBusinessLogic;
        }

        public string GetPeriodeId(string dateTime)
        {
            return _periodeBusinessLogic.GetPeriodeId(dateTime);
        }

        public void InsertPeriode(object obj)
        {
            _periodeBusinessLogic.InsertPeriode(obj);
        }

        public int SavePeriode()
        {
            return _periodeBusinessLogic.SavePeriode();
        }
    }
}
