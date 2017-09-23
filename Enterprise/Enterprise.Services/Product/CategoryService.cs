using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;

namespace Enterprise.Services.Product
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;
        private readonly ITblCategoryRepository _categoryRepository;
        public CategoryService(ICategoryBusinessLogic categoryBusinessLogic)
        {
            _categoryBusinessLogic = categoryBusinessLogic;
        }

        public IEnumerable<TblCategory> GetAllTblCategory()
        {
            return _categoryBusinessLogic.GetAllTblCategory();
        }

        public TblCategory GetTblCategoryByName(string categoryName)
        {
            return _categoryBusinessLogic.GetTblCategoryByName(categoryName);
        }

        public int SaveCategory()
        {
            return _categoryBusinessLogic.SaveCategory();
        }
    }
}
