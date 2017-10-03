using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.Core.Repository.ProductRepository
{
    public class TblProductSpecsRepository : ProductBaseRepository<TblProductSpecs>, ITblProductSpecsRepository
    {
        public TblProductSpecsRepository(ProductContext context) : base(context)
        {
        }
    }
}
