using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.Periode.Abstract
{
    public interface IPeriodeBusinessLogic
    {
        TblPeriode CreatePeriode(object obj);
        void InsertPeriode(object obj);
        int SavePeriode();
        string GetPeriodeId(string dateTime);
    }
}
