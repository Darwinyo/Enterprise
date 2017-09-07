using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Redis
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        public TestController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return _distributedCache.GetString(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            JObject jObject = (JObject)value;
            string key = jObject["Key"].ToString();
            string val = jObject["Value"].ToString();
            _distributedCache.SetString(key, val);
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
