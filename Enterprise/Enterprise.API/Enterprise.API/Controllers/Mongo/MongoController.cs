using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Enterprise.API.Models.Settings;
using Enterprise.Services.Mongo.Abstract;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Mongo
{
    [Route("api/[controller]")]
    public class MongoController : Controller
    {
        private readonly IProductCommentService _productCommentService;
        public MongoController(IProductCommentService productCommentService)
        {
            _productCommentService = productCommentService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<TblProductComments> Get(string id)
        {
            return _productCommentService.GetAllCommentListByProductId(id);
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
