using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product.Abstract
{
    public interface ICategoryBusinessLogic
    {
        void CheckAndInsertCategory(object categoryObj, ITblCategoryRepository context);
        void InsertCategory(TblCategory entity, ITblCategoryRepository context);
        bool IsCategoryExists(string categoryName, ITblCategoryRepository context);
        TblCategory CreateCategory(object categoryObj);
        TblCategory GetTblCategoryByName(string categoryName, ITblCategoryRepository context);
        IEnumerable<TblCategory> GetAllTblCategory(ITblCategoryRepository context);
        int SaveCategory(ITblCategoryRepository context);
    }
}
