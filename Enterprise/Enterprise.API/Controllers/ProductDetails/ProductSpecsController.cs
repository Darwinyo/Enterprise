using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Services.ProductDetails;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.ProductDetails.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.ProductDetails
{
    [Route("api/[controller]")]
    public class ProductSpecsController : Controller
    {
        private readonly IProductSpecsService _productSpecsService;
        public ProductSpecsController(IProductSpecsService productSpecsService)
        {
            _productSpecsService = productSpecsService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<TblProductSpecs> Get(string id)
        {
            return _productSpecsService.GetAllProductSpecsByProductId(id);
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
