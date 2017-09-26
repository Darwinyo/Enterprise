using Enterprise.Workflows.Helpers.Converters.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.Framework.DataLayers;
using Enterprise.Workflows.Models.Responses;
using Enterprise.Framework.DataLayers.DTOs.Product;

namespace Enterprise.Workflows.Helpers.Converters
{
    public class HotProductConverter : IHotProductConverter
    {
        public HotProductWorkflowResponse ConvertToResponse(IDictionary<string, object> dictionary)
        {
            return new HotProductWorkflowResponse
            {
                HotProductCards = (IEnumerable<ProductCardDTO>)dictionary["HotProductCards"]
            };
        }
    }
}
