using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.DataLayers.EnterpriseDB_HelperModel
{
    public partial class TblPeriode
    {
        public static int CreatePeriode(TblPeriode tblPeriode, HelperContext context)
        {
            return context.Database.ExecuteSqlCommand(
                 "EXEC dbo.sp_Generate_Periode @periodeId={0},@periodeDescription={1},@periodeStartDate={2},@periodeEndDate={3}"
                 , tblPeriode.PeriodeId
                 , tblPeriode.PeriodeDescription
                 , tblPeriode.PeriodeStartDate
                 , tblPeriode.PeriodeEndDate);
        }
    }
}
