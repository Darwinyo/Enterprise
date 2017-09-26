using Enterprise.API.Models.Responses;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.ProductRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Services.Product.Abstract
{
    public interface ICategoryService
    {
        Task<CategoryWorkflowResponse> AddCategory(object categoryObject);
        TblCategory GetTblCategoryByName(string categoryName);
        IEnumerable<TblCategory> GetAllTblCategory();
        int SaveCategory();
    }
}
