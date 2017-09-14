using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Enterprise.SignalR.Hubs;
using Enterprise.Services.Mongo;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Services.Mongo.Abstract;
using Newtonsoft.Json.Linq;
using Enterprise.API.Models.Hubs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Chat
{
    [Route("api/[controller]")]
    public class ChatController : ApiHubController<ChatHub>
    {
        private readonly IChatService _chatService;
        
        public ChatController(IChatService chatService, IConnectionManager connectionManager) : base(connectionManager)
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
        public IEnumerable<TblChat> Get(string id)
        {
            return _chatService.GetChatByGroupId(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            
            _chatService.InsertChat(value);
            JObject jObject = (JObject)value;
            ChatModel chatModel = new ChatModel
            {
                groupId = jObject["groupId"].ToString(),
                userId = jObject["userId"].ToString(),
                message = jObject["message"].ToString(),
                messageDatetime = (DateTime)jObject["messageDatetime"],
            };
            Clients.All.Send(chatModel);
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
