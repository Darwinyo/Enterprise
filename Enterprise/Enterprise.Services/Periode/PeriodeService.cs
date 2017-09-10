using Enterprise.Services.Periode.Abstract;
using Enterprise.API.BusinessLogics.Periode;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.Periode
{
    public class PeriodeService : IPeriodeService
    {
        private readonly PeriodeBusinessLogic _periodeBusinessLogic;
        private readonly ITblPeriodeRepository _periodeRepository;
        public PeriodeService(ITblPeriodeRepository periodeRepository)
        {
            _periodeBusinessLogic = new PeriodeBusinessLogic();
            _periodeRepository = periodeRepository;
        }

        public string GetPeriodeId(string dateTime)
        {
            return _periodeBusinessLogic.GetPeriodeId(dateTime, _periodeRepository);
        }

        public void InsertPeriode(object obj)
        {
            _periodeBusinessLogic.InsertPeriode(obj, _periodeRepository);
        }

        public int SavePeriode()
        {
            return _periodeBusinessLogic.SavePeriode(_periodeRepository);
        }
    }
}
