using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Core.Services.ProductDetails;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Services.ProductDetails.Abstract;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.ProductDetails
{
    [Route("api/[controller]")]
    public class ProductVariationController : Controller
    {
        private readonly IProductVariationService _productVariationService;
        public ProductVariationController(IProductVariationService productVariationService)
        {
            _productVariationService = productVariationService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<TblProductVariations> Get(string id)
        {
            return _productVariationService.GetProductVariationByProductId(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
