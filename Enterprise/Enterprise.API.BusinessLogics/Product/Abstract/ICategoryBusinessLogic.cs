using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product.Abstract
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
