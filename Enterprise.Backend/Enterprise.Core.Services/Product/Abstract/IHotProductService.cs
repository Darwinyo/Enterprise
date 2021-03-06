﻿using Enterprise.API.Models.Responses;
using Enterprise.Core.DataLayers.DTOs.Product;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Enterprise.Core.Services.Product.Abstract
{
    public interface IHotProductService
    {
        HotProductWorkflowResponse GetHotProductsByPeriodeId(string PeriodeId);
    }
}
