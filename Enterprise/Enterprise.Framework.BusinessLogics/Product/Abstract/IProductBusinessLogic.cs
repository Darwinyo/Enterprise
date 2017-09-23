using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        void AddNewProduct(Tbl_Product product);
        Tbl_Product CreateProductItem(object productObject);
        IEnumerable<Tbl_Product> GetAllListProduct();
        Tbl_Product GetProductById(string ProductId);
        void AddReview(string productId);
        int SaveProduct();
    }
}
