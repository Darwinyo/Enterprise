using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.DataLayers;

namespace Enterprise.API.Models.Responses
{
    public class HotProductWorkflowResponse
    {
        public IEnumerable<Tbl_Product> HotProducts { get; set; }
    }
}
