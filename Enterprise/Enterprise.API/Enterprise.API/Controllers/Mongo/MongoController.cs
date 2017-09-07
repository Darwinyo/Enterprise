using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MB = Enterprise.API.BusinessLogics;
using MM = Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Microsoft.Extensions.Options;
using Enterprise.API.Models.Settings;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Mongo
{
    [Route("api/[controller]")]
    public class MongoController : Controller
    {
        private readonly MM.MongoContext _context;
        public MongoController(IOptions<MongoDBSettings> options)
        {
            _context = new MM.MongoContext(options);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<MM.TblProductComments> Get(string id)
        {
            return MB.Mongo.TblProductCommentsBusinessLogic.GetAllCommentListByProductIdAsync(id, _context);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
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
