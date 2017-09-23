using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductRecommendedRepository : ProductBaseRepository<Tbl_Product_Recommended>, ITblProductRecommendedRepository
    {
        public TblProductRecommendedRepository(ProductContext context) : base(context)
        {
        }
    }
}
