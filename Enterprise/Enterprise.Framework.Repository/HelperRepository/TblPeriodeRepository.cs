using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.HelperRepository
{
    public class TblPeriodeRepository:HelperBaseRepository<Tbl_Periode>,ITblPeriodeRepository
    {
        public TblPeriodeRepository(HelperContext context) : base(context)
        {
        }

        public int CreatePeriode(Tbl_Periode tblPeriode, HelperContext context)
        {
            return context.Database.ExecuteSqlCommand(
                 "EXEC dbo.sp_Generate_Periode @periodeId={0},@periodeDescription={1},@periodeStartDate={2},@periodeEndDate={3}"
                 , tblPeriode.Periode_Id
                 , tblPeriode.Periode_Description
                 , tblPeriode.Periode_StartDate
                 , tblPeriode.Periode_EndDate);
        }
    }
}
