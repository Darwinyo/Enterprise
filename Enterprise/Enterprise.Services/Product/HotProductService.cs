using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Models.Responses;
using Enterprise.DataLayers.DTOs.Product;
using System.Threading.Tasks;
using Enterprise.API.Helpers.Consts;
using System.Net.Http;
using Newtonsoft.Json;

namespace Enterprise.Services.Product
{
    public class HotProductService : Bypasser<HotProductWorkflowResponse, string>, IHotProductService
    {
        private readonly IHotProductBusinessLogic _hotProductBusinessLogic;
        public HotProductService(IHotProductBusinessLogic hotProductBusinessLogic)
        {
            _hotProductBusinessLogic = hotProductBusinessLogic;
        }
        public HotProductWorkflowResponse GetHotProductsByPeriodeId(string PeriodeId)
        {
            return GetAction(WorkflowServiceClient.HotProduct + "/" + PeriodeId);
        }
    }
}
