using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;

namespace Enterprise.Framework.BusinessLogics.Periode.Abstract
{
    public interface IPeriodeBusinessLogic
    {
        Tbl_Periode CreatePeriode(object obj);
        void InsertPeriode(Tbl_Periode periode);
        int SavePeriode();
        string GetPeriodeId(string dateTime);
    }
}
