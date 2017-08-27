using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblCategory
    {
        public static bool IsCategoryExists(string categoryName, ProductContext context)
        {
            var res = context.TblCategory.Where(x => x.CategoryName == categoryName).LastOrDefault();
            if (res != null)
                return true;
            return false;
        }
        public static int InsertCategory(string categoryName, ProductContext context)
        {
            context.Add(new TblCategory
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryName = categoryName
            });
            return context.SaveChanges();
        }
        public static TblCategory GetTblCategoryByName(string categoryName, ProductContext context)
        {
            return context.TblCategory.Where(x => x.CategoryName == categoryName).LastOrDefault();
        }
        public static List<TblCategory> GetAllTableCategory(ProductContext context)
        {
            return context.TblCategory.ToList();
        }
    }
}
