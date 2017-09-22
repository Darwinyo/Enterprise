using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Periode.Abstract
{
    public interface IPeriodeBusinessLogic
    {
        TblPeriode CreatePeriode(object obj, ITblPeriodeRepository periodeRepository);
        void InsertPeriode(object obj, ITblPeriodeRepository periodeRepository);
        int SavePeriode(ITblPeriodeRepository periodeRepository);
        string GetPeriodeId(string dateTime, ITblPeriodeRepository periodeRepository);
    }
}
