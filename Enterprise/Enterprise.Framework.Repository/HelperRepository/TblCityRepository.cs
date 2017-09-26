using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;

namespace Enterprise.Framework.Repository.HelperRepository
{
    public class TblCityRepository : HelperBaseRepository<TblCity>, ITblCityRepository
    {
        public TblCityRepository(HelperContext context) : base(context)
        {
        }
    }
}
