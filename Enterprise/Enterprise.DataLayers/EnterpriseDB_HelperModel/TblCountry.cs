using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_HelperModel
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblCity = new HashSet<TblCity>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ICollection<TblCity> TblCity { get; set; }
    }
}
