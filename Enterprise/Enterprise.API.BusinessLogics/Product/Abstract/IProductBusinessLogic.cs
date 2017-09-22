using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        void AddNewProduct(object obj, ITblProductRepository context, ITblCategoryRepository categoryRepository);
        TblProduct CreateProductItem(JObject jObject, ITblCategoryRepository categoryRepository, CategoryBusinessLogic categoryBusinessLogic);
        IEnumerable<TblProduct> GetAllListProduct(ITblProductRepository context);
        TblProduct GetProductById(string ProductId, ITblProductRepository context);
        void AddReview(string productId, ITblProductRepository context);
        int SaveProduct(ITblProductRepository context);
    }
}
