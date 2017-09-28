using Enterprise.API.Models.Responses;
using Enterprise.DataLayers.DTOs.Product;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Services.Product.Abstract
{
    public interface IProductService
    {
        Task<InsertProductWorkflowResponse> AddNewProduct(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        ProductDetailsDTO GetProductDetails(string productId);
        void AddReview(string productId);
    }
}
