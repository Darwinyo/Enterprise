using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;
using PB = Enterprise.API.BusinessLogics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.ProductDetails
{
    [Route("api/[controller]")]
    public class ProductVariationController : Controller
    {
        private readonly PM.ProductContext _context;
        public ProductVariationController(PM.ProductContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<PM.TblProductVariations> Get(string id)
        {
            return PB.ProductDetails.ProductVariationBusinessLogic.GetProductVariationByProductId(id, _context);
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
