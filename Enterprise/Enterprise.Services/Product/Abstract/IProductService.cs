using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;

namespace Enterprise.Services.Product.Abstract
{
    public interface IProductService
    {
        void AddNewProduct(object obj);
        IEnumerable<TblProduct> GetAllListProduct();
        TblProduct GetProductById(string ProductId);
        void AddReview(string productId);
        int SaveProduct();
    }
}
