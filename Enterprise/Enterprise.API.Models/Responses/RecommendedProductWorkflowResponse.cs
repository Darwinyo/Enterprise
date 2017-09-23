using Enterprise.Framework.DataLayers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.Models.Responses
{
    public class RecommendedProductWorkflowResponse
    {
        public IEnumerable<Tbl_Product> RecommendedProducts { get; set; }
    }
}
