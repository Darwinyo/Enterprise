using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;

namespace Enterprise.Core.Repository.HelperRepository
{
    public class TblCityRepository : HelperBaseRepository<TblCity>, ITblCityRepository
    {
        public TblCityRepository(HelperContext context) : base(context)
        {
        }
    }
}
