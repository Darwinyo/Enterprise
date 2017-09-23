using System.Collections.Generic;
using Enterprise.API.BusinessLogics.Mongo.Abstract;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.Abstract;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.Extensions.Options;
using Enterprise.API.Models.Settings;

namespace Enterprise.API.BusinessLogics.Mongo
{
    public class ChatBusinessLogic : IChatBusinessLogic
    {
        private readonly MongoContext _context;
        private readonly ITblChatRepository _chatRepository;
        public ChatBusinessLogic(ITblChatRepository chatRepository, IOptions<MongoDBSettings> options)
        {
            _chatRepository = chatRepository;
            _context = new MongoContext(options);
        }
        public TblChat CreateChatObject(object obj)
        {
            JObject jObject = (JObject)obj;
            TblChat tblChat = new TblChat
            {
                GroupId = jObject["groupId"].ToString(),
                Message = jObject["message"].ToString(),
                MessageDatetime = DateTime.Parse(jObject["messageDatetime"].ToString()),
                UserId = jObject["userId"].ToString()
            };
            return tblChat;
        }

        public IEnumerable<TblChat> GetChatByGroupId(string groupId)
        {
            IMongoQuery mongoQuery = Query<TblChat>.EQ(x => x.GroupId, groupId);
            return _chatRepository.FindBy(_context.TblChat, mongoQuery).AsEnumerable();
        }

        public void InsertChat(object obj)
        {
            TblChat tblChat = CreateChatObject(obj);
            _chatRepository.Add(_context.TblChat, tblChat);
        }
    }
}
