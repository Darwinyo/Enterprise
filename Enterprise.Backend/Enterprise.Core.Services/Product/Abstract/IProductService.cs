using Enterprise.API.Models.Responses;
using Enterprise.Core.DataLayers.DTOs.Product;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Core.Services.Product.Abstract
{
    public interface IProductService
    {
        Task<InsertProductWorkflowResponse> AddNewProduct(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        ProductDetailsDTO GetProductDetails(string productId);
        void AddReview(string productId);
    }
}
