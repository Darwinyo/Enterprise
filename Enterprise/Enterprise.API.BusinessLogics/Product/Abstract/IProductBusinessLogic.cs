using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        TblProduct CreateProductItem(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        TblProduct GetProductById(string ProductId);
        void AddReview(string productId);
    }
}
