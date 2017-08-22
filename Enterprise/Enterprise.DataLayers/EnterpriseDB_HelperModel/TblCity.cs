using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_HelperModel
{
    public partial class TblCity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public TblCountry Country { get; set; }
    }
}
