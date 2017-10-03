using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.Core.Repository.ProductRepository
{
    public class TblCategoryRepository:ProductBaseRepository<TblCategory>,ITblCategoryRepository
    {
        public TblCategoryRepository(ProductContext context) : base(context)
        {
        }
    }
}
