using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Repository.Abstract;
using Enterprise.Repository.ProductRepository;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public class TblProductRecommendedRepository : ProductBaseRepository<TblProductRecommended>, ITblProductRecommendedRepository
    {
        public TblProductRecommendedRepository(ProductContext context) : base(context)
        {
        }
    }
}
