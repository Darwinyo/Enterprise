using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;
using PB = Enterprise.API.BusinessLogics.Product.ProductBusinessLogic;
using Enterprise.API.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Product
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly PM.ProductContext _context;

        public ProductController(PM.ProductContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<PM.TblProduct> Get()
        {
            return PB.GetAllListProduct(_context);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PM.TblProduct Get(string id)
        {
            return PB.GetListProductById(id, _context);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            PB.AddNewProduct(value, _context);
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
