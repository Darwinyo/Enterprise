using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Repository.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.Repository.ProductRepository
{
    public class TblProductSpecsRepository : ProductBaseRepository<TblProductSpecs>, ITblProductSpecsRepository
    {
        public TblProductSpecsRepository(ProductContext context) : base(context)
        {
        }
    }
}
