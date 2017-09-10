using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using Enterprise.Repository.ProductRepository;
namespace Enterprise.Repository.ProductRepository
{
    public class TblProductHotRepository : ProductBaseRepository<TblProductHot>, ITblProductHotRepository
    {
        public TblProductHotRepository(ProductContext context) : base(context)
        {
        }
    }
}
