using Enterprise.API.Models.Responses;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Services.Product.Abstract
{
    public interface IProductService
    {
        Task<InsertProductWorkflowResponse> AddNewProduct(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        TblProduct GetProductById(string ProductId);
        void AddReview(string productId);
    }
}
