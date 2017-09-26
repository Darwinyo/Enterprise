using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;

namespace Enterprise.Framework.BusinessLogics.Periode.Abstract
{
    public interface IPeriodeBusinessLogic
    {
        TblPeriode CreatePeriode(object obj);
        void InsertPeriode(TblPeriode periode);
        int SavePeriode();
        string GetPeriodeId(string dateTime);
    }
}
