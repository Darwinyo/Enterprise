using Enterprise.Framework.DataLayers.Extend.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.DataLayers
{
    public partial class ProductContext:IProductContext
    {
        public ProductContext(string conString):base(conString)
        {

        }
    }
}
