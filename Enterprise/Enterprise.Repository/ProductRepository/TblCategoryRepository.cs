using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.Repository.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.Repository.ProductRepository
{
    public class TblCategoryRepository:ProductBaseRepository<TblCategory>,ITblCategoryRepository
    {
        public TblCategoryRepository(ProductContext context) : base(context)
        {
        }
    }
}
