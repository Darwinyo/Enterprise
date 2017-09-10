using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.Repository.ProductRepository
{
    public class TblProductRepository:ProductBaseRepository<TblProduct>,ITblProductRepository
    {
        public TblProductRepository(ProductContext context) : base(context)
        {
        }
        
        public IEnumerable<TblProduct> GetListProductByListString(List<string> listProductId)
        {
            var x= base._context.TblProduct.Where(z => listProductId.Contains(z.ProductId)).ToList();
            x.ForEach(z =>
            {
                z.TblProductHot = null;
                z.TblProductRecommended = null;
            });
            return x.AsEnumerable();
        }
        public void AddReview(string productId)
        {
            base._context.Database.ExecuteSqlCommand("EXEC dbo.sp_AddReview @productId={0}",
                productId);
        }
    }
}
