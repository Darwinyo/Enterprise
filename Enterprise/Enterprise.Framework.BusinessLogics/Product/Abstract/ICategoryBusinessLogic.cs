using System.Collections.Generic;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface ICategoryBusinessLogic
    {
        void InsertCategory(Tbl_Category entity);
        bool IsCategoryExists(string categoryName);
        Tbl_Category CreateCategory(object categoryObj);
        Tbl_Category GetTblCategoryByName(string categoryName);
        IEnumerable<Tbl_Category> GetAllTblCategory();
        int SaveCategory();
    }
}
