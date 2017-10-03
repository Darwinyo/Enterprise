using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Core.Services.User.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;
using Enterprise.API.Models.Responses;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.User
{
    [Route("api/[controller]")]
    public class UserLoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDistributedCache _distributedCache;
        public UserLoginController(IUserService userService, IDistributedCache distributedCache)
        {
            _userService = userService;
            _distributedCache = distributedCache;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<UserLoginResponse> Get(string id)
        {
            var value = await _distributedCache.GetAsync(id);
            return JsonConvert.DeserializeObject<UserLoginResponse>(Encoding.UTF8.GetString(value));
        }

        // POST api/values
        [HttpPost]
        public async Task<UserLoginResponse> Post([FromBody]object value)
        {
            JObject jObject = (JObject)value;
            bool rememberMe = Convert.ToBoolean(jObject["rememberme"]?.ToString());
            string userLogin = jObject["userLogin"].ToString();
            string password = jObject["password"].ToString();
            UserLoginResponse userLoginResponse = await _userService.LoginUser(userLogin,password);
            if (rememberMe && userLoginResponse.IsLogged)
            {
                await _distributedCache.SetAsync(userLoginResponse.UserKey,
                    Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userLoginResponse)),
                    new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(new TimeSpan(1, 0, 0, 0)));
            }
            return userLoginResponse;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _distributedCache.RemoveAsync(id);
        }
    }
}
