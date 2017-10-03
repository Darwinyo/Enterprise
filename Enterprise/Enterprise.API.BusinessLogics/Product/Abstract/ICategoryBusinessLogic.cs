using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.Product.Abstract
{
    public interface ICategoryBusinessLogic
    {
        void InsertCategory(TblCategory entity);
        bool IsCategoryExists(string categoryName);
        TblCategory CreateCategory(object categoryObj);
        TblCategory GetTblCategoryByName(string categoryName);
        IEnumerable<TblCategory> GetAllTblCategory();
        int SaveCategory();
    }
}
