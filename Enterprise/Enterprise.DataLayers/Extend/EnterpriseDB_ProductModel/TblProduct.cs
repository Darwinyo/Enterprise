using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
        public static TblProduct GetListProductById(string ProductId, ProductContext context)
        {
            return context.TblProduct.Where(x => x.ProductId == ProductId).FirstOrDefault();
        }
        public static List<TblProduct> GetListProductByListString(List<string> listProductId,ProductContext context)
        {
            return context.TblProduct.Where(x => listProductId.Contains(x.ProductId)).ToList();
        }
    }
}
