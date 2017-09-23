using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Periode.Abstract
{
    public interface IPeriodeBusinessLogic
    {
        TblPeriode CreatePeriode(object obj);
        void InsertPeriode(object obj);
        int SavePeriode();
        string GetPeriodeId(string dateTime);
    }
}
