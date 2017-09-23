using Enterprise.Workflows.Helpers.Converters.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.API.Models.Responses;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Workflows.Helpers.Converters
{
    public class RecommendedProductConverter : IRecommendedProductConverter
    {
        public RecommendedProductWorkflowResponse ConvertToResponse(IDictionary<string, object> dictionary)
        {
            return new RecommendedProductWorkflowResponse
            {
                RecommendedProducts = (IEnumerable<Tbl_Product>)dictionary["RecommendedProducts"]
            };
        }
    }
}
