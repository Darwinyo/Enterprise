using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProduct
    {
        public static int AddNewProduct(TblProduct product, ProductContext context)
        {
            context.TblProduct.Add(product);
            return context.SaveChanges();
        }
        public static List<TblProduct> GetAllListProduct(ProductContext context)
        {
            return context.TblProduct.ToList();
        }
        public static TblProduct GetProductById(string productId, ProductContext context)
        {
            return context.TblProduct.Where(x => x.ProductId == productId).FirstOrDefault();
        }
        public static List<TblProduct> GetListProductByListString(List<string> listProductId,ProductContext context)
        {
            var x= context.TblProduct.Where(z => listProductId.Contains(z.ProductId)).ToList();
            x.ForEach(z =>
            {
                z.TblProductHot = null;
                z.TblProductRecommended = null;
            });
            return x;
        }
        public static void AddReview(string productId,ProductContext context)
        {
            context.Database.ExecuteSqlCommand("EXEC dbo.sp_AddReview @productId={0}",
                productId);
        }
    }
}
