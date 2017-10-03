using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.Repository.ProductRepository;

namespace Enterprise.Core.DataLayers.EnterpriseDB_ProductModel
{
    public class TblProductVariationsRepository : ProductBaseRepository<TblProductVariations>, ITblProductVariationsRepository
    {
        public TblProductVariationsRepository(ProductContext context) : base(context)
        {
        }
    }
}
