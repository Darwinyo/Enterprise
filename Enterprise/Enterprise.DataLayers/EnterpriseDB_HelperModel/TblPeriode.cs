using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_HelperModel
{
    public partial class TblPeriode
    {
        public string PeriodeId { get; set; }
        public string PeriodeDescription { get; set; }
        public DateTime PeriodeStartDate { get; set; }
        public DateTime PeriodeEndDate { get; set; }
    }
}
