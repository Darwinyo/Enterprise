using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.Repository.ProductRepository;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductSpecsRepository : ProductBaseRepository<Tbl_Product_Specs>, ITblProductSpecsRepository
    {
        public TblProductSpecsRepository(ProductContext context) : base(context)
        {
        }
    }
}
