using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.DTOs.Product;

namespace Enterprise.Core.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        TblProduct CreateProductItem(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        ProductDetailsDTO GetProductDetails(string productId);
        void AddReview(string productId);
    }
}
