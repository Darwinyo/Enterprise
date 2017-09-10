using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Repository.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;

namespace Enterprise.Repository.HelperRepository
{
    public class TblCityRepository : HelperBaseRepository<TblCity>, ITblCityRepository
    {
        public TblCityRepository(HelperContext context) : base(context)
        {
        }
    }
}
