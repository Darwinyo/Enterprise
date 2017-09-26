using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.DataLayers;
using Enterprise.DataLayers.DTOs.Product;

namespace Enterprise.API.Models.Responses
{
    public class HotProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> HotProductCards { get; set; }
    }
}
