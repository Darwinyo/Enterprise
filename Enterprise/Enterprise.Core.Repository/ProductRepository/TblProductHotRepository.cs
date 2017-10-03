using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.Repository.ProductRepository;
namespace Enterprise.Core.Repository.ProductRepository
{
    public class TblProductHotRepository : ProductBaseRepository<TblProductHot>, ITblProductHotRepository
    {
        public TblProductHotRepository(ProductContext context) : base(context)
        {
        }
    }
}
