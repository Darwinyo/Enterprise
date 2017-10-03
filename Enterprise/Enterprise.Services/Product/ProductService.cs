using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.Product.Abstract;
using Enterprise.Core.BusinessLogics.Product;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using System.Net.Http;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Models.Responses;
using System.Threading.Tasks;
using Enterprise.API.Helpers.Consts;
using Enterprise.Core.DataLayers.DTOs.Product;

namespace Enterprise.Core.Services.Product
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
