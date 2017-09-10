namespace Enterprise.Services.Periode.Abstract
{
    public interface IPeriodeService
    {
        void InsertPeriode(object obj);
        int SavePeriode();
        string GetPeriodeId(string dateTime);
    }
}
