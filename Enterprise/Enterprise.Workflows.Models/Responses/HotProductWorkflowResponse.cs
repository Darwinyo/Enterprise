using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;

namespace Enterprise.Workflows.Models.Responses
{
    public class HotProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> HotProductCards { get; set; }
    }
}
