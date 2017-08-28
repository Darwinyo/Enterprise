using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;
using PB = Enterprise.API.BusinessLogics.Product.CategoryBusinessLogic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Product
{
    [Route("api/[controller]")]
    public class CategoryProductController : Controller
    {
        private readonly PM.ProductContext _context;
        public CategoryProductController(PM.ProductContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<PM.TblCategory> Get()
        {
            return PB.GetAllTblCategory(_context);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            PB.CheckAndInsertCategory(value, _context);
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
