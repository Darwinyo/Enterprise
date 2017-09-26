using System.Collections.Generic;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
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
