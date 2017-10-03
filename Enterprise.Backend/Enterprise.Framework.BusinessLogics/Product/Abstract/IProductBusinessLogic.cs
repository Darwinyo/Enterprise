using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        void AddNewProduct(TblProduct product);
        TblProduct CreateProductItem(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        TblProduct GetProductById(string ProductId);
        void AddReview(string productId);
        int SaveProduct();
    }
}
