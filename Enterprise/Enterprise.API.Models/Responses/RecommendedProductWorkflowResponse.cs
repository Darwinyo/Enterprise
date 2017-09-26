using Enterprise.DataLayers.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.Models.Responses
{
    public class RecommendedProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> RecommendedProductCards { get; set; }
    }
}
