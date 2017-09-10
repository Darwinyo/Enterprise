using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Enterprise.Services.Mongo.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Mongo
{
    [Route("api/[controller]")]
    public class ChatController : ApiHubController<ChatHub>
    {
        private readonly IChatService _chatService;

        protected ChatController(IChatService chatService, IConnectionManager connectionManager) : base(connectionManager)
        {
            _chatService = chatService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
            _chatService.InsertChat(value);
            
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
