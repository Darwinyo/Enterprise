using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.Repository.ProductRepository
{
    public class TblProductImageRepository : ProductBaseRepository<TblProductImage>, ITblProductImageRepository
    {
        public TblProductImageRepository(ProductContext context) : base(context)
        {
        }
    }
}
