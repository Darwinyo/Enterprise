using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Framework.Repository.ProductRepository;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductImageRepository : ProductBaseRepository<TblProductImage>, ITblProductImageRepository
    {
        public TblProductImageRepository(ProductContext context) : base(context)
        {
        }
    }
}
