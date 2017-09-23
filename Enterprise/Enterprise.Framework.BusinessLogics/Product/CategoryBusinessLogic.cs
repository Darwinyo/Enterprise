using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.BusinessLogics.Product
{
    public class CategoryBusinessLogic : ICategoryBusinessLogic
    {
        private readonly ITblCategoryRepository _categoryRepository;
        public CategoryBusinessLogic(ITblCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Tbl_Category CreateCategory(object categoryObj)
        {
            JObject jObject = (JObject)categoryObj;
            Tbl_Category tblCategory = new Tbl_Category
            {
                Category_Id = Guid.NewGuid().ToString(),
                Category_Image_Url = jObject["categoryImageUrl"].ToString(),
                Category_Name = jObject["categoryName"].ToString()
            };
            return tblCategory;
        }
        public Tbl_Category GetTblCategoryByName(string categoryName)
        {
            return _categoryRepository.GetSingle(x => x.Category_Name == categoryName);
        }
        public IEnumerable<Tbl_Category> GetAllTblCategory()
        {
            return _categoryRepository.GetAll();
        }

        public void InsertCategory(Tbl_Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public bool IsCategoryExists(string categoryName)
        {
            if (_categoryRepository.FindBy(x => x.Category_Name == categoryName).Count() > 0)
                return true;
            return false;
        }

        public int SaveCategory()
        {
            return _categoryRepository.Commit();
        }
    }
}
