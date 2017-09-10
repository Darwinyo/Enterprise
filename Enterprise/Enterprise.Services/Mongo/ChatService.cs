using Enterprise.Services.Mongo.Abstract;
using System;
using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.MongoRepository;
using Enterprise.API.BusinessLogics.Mongo;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;

namespace Enterprise.Services.Mongo
{
    public class ChatService : IChatService
    {
        private readonly TblChatRepository _chatRepository;
        private readonly ChatBusinessLogic _chatBusinessLogic;
        public ChatService(TblChatRepository chatRepository, IOptions<MongoDBSettings> options)
        {
            _chatBusinessLogic = new ChatBusinessLogic(new MongoContext(options));
            _chatRepository = chatRepository;
        }
        public IEnumerable<TblChat> GetChatByGroupId(string groupId)
        {
            return _chatBusinessLogic.GetChatByGroupId(groupId, _chatRepository);
        }

        public void InsertChat(object obj)
        {
            _chatBusinessLogic.InsertChat(obj, _chatRepository);
        }
    }
}
