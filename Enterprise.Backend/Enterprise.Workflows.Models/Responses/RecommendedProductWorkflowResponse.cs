using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Workflows.Models.Responses
{
    public class RecommendedProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> RecommendedProductCards { get; set; }
    }
}
