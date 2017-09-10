using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.Product
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryBusinessLogic _categoryBusinessLogic;
        private readonly ITblCategoryRepository _categoryRepository;
        public CategoryService(ITblCategoryRepository categoryRepository)
        {
            _categoryBusinessLogic = new CategoryBusinessLogic();
            _categoryRepository = categoryRepository;
        }
        public void CheckAndInsertCategory(object categoryObj)
        {
            _categoryBusinessLogic.CheckAndInsertCategory(categoryObj, _categoryRepository);
        }

        public IEnumerable<TblCategory> GetAllTblCategory()
        {
            return _categoryBusinessLogic.GetAllTblCategory(_categoryRepository);
        }

        public TblCategory GetTblCategoryByName(string categoryName)
        {
            return _categoryBusinessLogic.GetTblCategoryByName(categoryName, _categoryRepository);
        }

        public int SaveCategory()
        {
            return _categoryBusinessLogic.SaveCategory(_categoryRepository);
        }
    }
}
