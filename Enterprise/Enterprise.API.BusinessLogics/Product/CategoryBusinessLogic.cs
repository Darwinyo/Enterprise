using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Newtonsoft.Json.Linq;
using Enterprise.API.BusinessLogics.Product.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product
{
    public class CategoryBusinessLogic : ICategoryBusinessLogic
    {
        public void CheckAndInsertCategory(object categoryObj, ITblCategoryRepository context)
        {
            if (categoryObj != null)
            {
                TblCategory category = CreateCategory(categoryObj);
                if (!IsCategoryExists(category.CategoryName, context))
                    InsertCategory(category, context);
            }
        }
        public TblCategory CreateCategory(object categoryObj)
        {
            JObject jObject = (JObject)categoryObj;
            TblCategory tblCategory = new TblCategory
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryImageUrl = jObject["categoryImageUrl"].ToString(),
                CategoryName = jObject["categoryName"].ToString()
            };
            return tblCategory;
        }
        public TblCategory GetTblCategoryByName(string categoryName, ITblCategoryRepository context)
        {
            if (IsCategoryExists(categoryName,context))
                return context.GetSingle(x=>x.CategoryName==categoryName);
            return null;
        }
        public IEnumerable<TblCategory> GetAllTblCategory(ITblCategoryRepository context)
        {
            return context.GetAll();
        }

        public void InsertCategory(TblCategory entity, ITblCategoryRepository context)
        {
            context.Add(entity);
        }

        public bool IsCategoryExists(string categoryName, ITblCategoryRepository context)
        {
            if (context.FindBy(x => x.CategoryName == categoryName).Count() > 0)
                return true;
            return false;
        }

        public int SaveCategory(ITblCategoryRepository context)
        {
            return context.Commit();
        }
    }
}
