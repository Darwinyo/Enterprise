using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.Product.Abstract;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Models.Responses;
using Enterprise.Core.DataLayers.DTOs.Product;
using System.Threading.Tasks;
using Enterprise.API.Helpers.Consts;
using System.Net.Http;
using Newtonsoft.Json;

namespace Enterprise.Core.Services.Product
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
