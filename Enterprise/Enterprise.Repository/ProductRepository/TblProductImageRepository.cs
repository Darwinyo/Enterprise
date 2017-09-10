using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.Repository.ProductRepository
{
    public class TblProductImageRepository : ProductBaseRepository<TblProductImage>, ITblProductImageRepository
    {
        public TblProductImageRepository(ProductContext context) : base(context)
        {
        }
    }
}
