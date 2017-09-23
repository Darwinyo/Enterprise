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
        private readonly ITblCategoryRepository _categoryRepository;
        public CategoryBusinessLogic(ITblCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
        public TblCategory GetTblCategoryByName(string categoryName)
        {
            return _categoryRepository.GetSingle(x => x.CategoryName == categoryName);
        }
        public IEnumerable<TblCategory> GetAllTblCategory()
        {
            return _categoryRepository.GetAll();
        }

        public void InsertCategory(TblCategory entity)
        {
            _categoryRepository.Add(entity);
        }

        public bool IsCategoryExists(string categoryName)
        {
            if (_categoryRepository.FindBy(x => x.CategoryName == categoryName).Count() > 0)
                return true;
            return false;
        }

        public int SaveCategory()
        {
            return _categoryRepository.Commit();
        }
    }
}
