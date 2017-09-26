using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;
using Enterprise.API.Models.Responses;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Helpers.Consts;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Enterprise.Services.Product
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
