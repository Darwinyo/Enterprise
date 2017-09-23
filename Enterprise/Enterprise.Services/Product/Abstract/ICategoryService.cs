using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.ProductRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Services.Product.Abstract
{
    public interface ICategoryService
    {
        TblCategory GetTblCategoryByName(string categoryName);
        IEnumerable<TblCategory> GetAllTblCategory();
        int SaveCategory();
    }
}
