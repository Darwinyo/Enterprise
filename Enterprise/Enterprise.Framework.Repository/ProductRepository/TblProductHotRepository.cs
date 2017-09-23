using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.Repository.ProductRepository;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductHotRepository : ProductBaseRepository<Tbl_Product_Hot>, ITblProductHotRepository
    {
        public TblProductHotRepository(ProductContext context) : base(context)
        {
        }
    }
}
