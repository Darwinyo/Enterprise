using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Newtonsoft.Json.Linq;
namespace Enterprise.API.BusinessLogics.Product
{
    public class CategoryBusinessLogic
    {
        public static bool CheckAndInsertCategory(object categoryObj, PM.ProductContext context)
        {
            if (categoryObj != null)
                return false;
            PM.TblCategory category = CreateCategory(categoryObj);
            int res = 0;
            if (PM.TblCategory.IsCategoryExists(category.CategoryName, context))
                return true;
            res = PM.TblCategory.InsertCategory(category, context);
            if (res != 0)
                return true;
            return false;
        }
        public static PM.TblCategory CreateCategory(object categoryObj)
        {
            JObject jObject = (JObject)categoryObj;
            PM.TblCategory tblCategory = new PM.TblCategory
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryImageUrl = jObject["categoryImageUrl"].ToString(),
                CategoryName = jObject["categoryName"].ToString()
            };
            return tblCategory;
        }
        public static PM.TblCategory GetTblCategoryByName(string categoryName, PM.ProductContext context)
        {
            if (CheckAndInsertCategory(categoryName, context))
                return PM.TblCategory.GetTblCategoryByName(categoryName, context);
            return null;
        }
        public static List<PM.TblCategory> GetAllTblCategory(PM.ProductContext context)
        {
            return PM.TblCategory.GetAllTableCategory(context);
        }
    }
}
