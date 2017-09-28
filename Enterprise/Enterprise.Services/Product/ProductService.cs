using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;
using System.Net.Http;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Models.Responses;
using System.Threading.Tasks;
using Enterprise.API.Helpers.Consts;
using Enterprise.DataLayers.DTOs.Product;

namespace Enterprise.Services.Product
{
    public class ProductService : Bypasser<InsertProductWorkflowResponse, object>, IProductService
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        public ProductService(IProductBusinessLogic productBusinessLogic)
        {
            _productBusinessLogic = productBusinessLogic;
        }
        public async Task<InsertProductWorkflowResponse> AddNewProduct(object productObject)
        {
            return await PostAction(WorkflowServiceClient.InsertProduct, productObject);
        }

        public void AddReview(string productId)
        {
            _productBusinessLogic.AddReview(productId);
        }

        public IEnumerable<TblProduct> GetAllListProduct()
        {
            return _productBusinessLogic.GetAllListProduct();
        }

        public ProductDetailsDTO GetProductDetails(string productId)
        {
            return _productBusinessLogic.GetProductDetails(productId);
        }
    }
}
