using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.API.BusinessLogics.Product
{
    public class CategoryBusinessLogic
    {
        public static bool CheckAndInsertCategory(string categoryName, PM.ProductContext context)
        {
            int res = 0;
            if (PM.TblCategory.IsCategoryExists(categoryName, context))
                return true;
            res = PM.TblCategory.InsertCategory(categoryName, context);
            if (res != 0)
                return true;
            return false;
        }
        public static PM.TblCategory GetTblCategoryByName(string categoryName, PM.ProductContext context)
        {
            if (CheckAndInsertCategory(categoryName, context))
                return PM.TblCategory.GetTblCategoryByName(categoryName, context);
            return null;
        }
    }
}
