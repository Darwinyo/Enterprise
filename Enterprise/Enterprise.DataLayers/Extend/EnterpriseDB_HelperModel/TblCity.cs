﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Enterprise.DataLayers.EnterpriseDB_HelperModel
{
    public partial class TblCity
    {
        public static List<TblCity> GetListOfCity(HelperContext context)
        {
            return context.TblCity.ToList();
        }
    }
}
