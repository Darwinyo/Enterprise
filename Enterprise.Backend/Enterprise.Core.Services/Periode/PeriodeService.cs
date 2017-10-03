using Enterprise.Core.Services.Periode.Abstract;
using Enterprise.Core.BusinessLogics.Periode;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.BusinessLogics.Periode.Abstract;

namespace Enterprise.Core.Services.Periode
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
