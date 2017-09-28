using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Repository.Abstract;
using Enterprise.DataLayers.DTOs.Product;

namespace Enterprise.API.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        TblProduct CreateProductItem(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        ProductDetailsDTO GetProductDetails(string productId);
        void AddReview(string productId);
    }
}
