using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.Product.Abstract;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using Enterprise.API.Models.Responses;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Helpers.Consts;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Enterprise.Core.DataLayers.DTOs.Product;

namespace Enterprise.Core.Services.Product
{
    public class RecommendedProductService : Bypasser<RecommendedProductWorkflowResponse, string>, IRecommendedProductService
    {
        private readonly IRecommendedProductBusinessLogic _recommendedProductBusinessLogic;
        public RecommendedProductService(IRecommendedProductBusinessLogic recommendedProductBusinessLogic)
        {
            _recommendedProductBusinessLogic = recommendedProductBusinessLogic;
        }
        public RecommendedProductWorkflowResponse GetRecommendedProductsByPeriodeId(string PeriodeId)
        {
            return GetAction(WorkflowServiceClient.RecommendedProduct + "/" + PeriodeId);
        }
    }
}
