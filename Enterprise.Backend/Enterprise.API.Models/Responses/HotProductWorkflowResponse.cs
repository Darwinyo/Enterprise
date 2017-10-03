using Enterprise.Core.DataLayers.DTOs.Product;
using System;
using System.Collections.Generic;

namespace Enterprise.API.Models.Responses
{
    public class HotProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> HotProductCards { get; set; }
    }
}
