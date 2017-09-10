using System.Collections.Generic;
using Enterprise.API.BusinessLogics.Mongo.Abstract;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.Abstract;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enterprise.API.BusinessLogics.Mongo
{
    public class ChatBusinessLogic : IChatBusinessLogic
    {
        private readonly MongoContext _context;
        public ChatBusinessLogic(MongoContext context)
        {
            _context = context;
        }

        public TblChat CreateChatObject(object obj)
        {
            JObject jObject = (JObject)obj;
            TblChat tblChat = new TblChat
            {
                GroupId = jObject["groupId"].ToString(),
                Message = jObject["message"].ToString(),
                MessageDatetime = jObject["messageDatetime"].ToString(),
                UserId = jObject["userId"].ToString()
            };
            return tblChat;
        }

        public IEnumerable<TblChat> GetChatByGroupId(string groupId, ITblChatRepository chatRepository)
        {
            IMongoQuery mongoQuery = Query<TblChat>.EQ(x => x.GroupId, groupId);
            return chatRepository.FindBy(_context.TblChat, mongoQuery).AsEnumerable();
        }

        public void InsertChat(object obj, ITblChatRepository chatRepository)
        {
            TblChat tblChat = CreateChatObject(obj);
            chatRepository.Add(_context.TblChat, tblChat);
        }
    }
}
