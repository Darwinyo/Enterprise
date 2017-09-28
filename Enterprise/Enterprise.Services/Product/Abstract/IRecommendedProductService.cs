using Enterprise.API.Models.Responses;
using Enterprise.DataLayers.DTOs.Product;
using System.Net.Http;
using System.Threading.Tasks;

namespace Enterprise.Services.Product.Abstract
{
    public interface IRecommendedProductService
    {
        RecommendedProductWorkflowResponse GetRecommendedProductsByPeriodeId(string PeriodeId);
    }
}
