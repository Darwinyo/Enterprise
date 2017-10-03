using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.Repository.ProductRepository;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblCategoryRepository:ProductBaseRepository<TblCategory>,ITblCategoryRepository
    {
        public TblCategoryRepository(ProductContext context) : base(context)
        {
        }
    }
}
