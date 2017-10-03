using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.Product.Abstract;
using Enterprise.Core.BusinessLogics.Product;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Models.Responses;
using System.Threading.Tasks;
using Enterprise.API.Helpers.Consts;

namespace Enterprise.Core.Services.Product
{
    public class CategoryService :Bypasser<CategoryWorkflowResponse,object>,  ICategoryService
    {
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;
        public CategoryService(ICategoryBusinessLogic categoryBusinessLogic)
        {
            _categoryBusinessLogic = categoryBusinessLogic;
        }
        public async Task<CategoryWorkflowResponse> AddCategory(object categoryObject)
        {
            return await PostAction(WorkflowServiceClient.Category, categoryObject);
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
