using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductRepository:ProductBaseRepository<Tbl_Product>,ITblProductRepository
    {
        public TblProductRepository(ProductContext context) : base(context)
        {
        }
        
        public IEnumerable<Tbl_Product> GetListProductByListString(List<string> listProductId)
        {
            var x= base._context.Tbl_Product.Where(z => listProductId.Contains(z.Product_Id)).ToList();
            x.ForEach(z =>
            {
                z.Tbl_Product_Hot = null;
                z.Tbl_Product_Recommended = null;
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
