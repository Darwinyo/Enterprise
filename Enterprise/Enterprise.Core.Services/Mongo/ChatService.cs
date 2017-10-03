using Enterprise.Core.Services.Mongo.Abstract;
using System;
using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.BusinessLogics.Mongo;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.BusinessLogics.Mongo.Abstract;

namespace Enterprise.Core.Services.Mongo
{
    public class ChatService : IChatService
    {
        private readonly IChatBusinessLogic _chatBusinessLogic;
        public ChatService(IChatBusinessLogic chatBusinessLogic)
        {
            _chatBusinessLogic = chatBusinessLogic;
        }
        public IEnumerable<TblChat> GetChatByGroupId(string groupId)
        {
            return _chatBusinessLogic.GetChatByGroupId(groupId);
        }

        public void InsertChat(object obj)
        {
            _chatBusinessLogic.InsertChat(obj);
        }
    }
}
