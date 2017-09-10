using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.Mongo.Abstract
{
    public interface IChatBusinessLogic
    {
        IEnumerable<TblChat> GetChatByGroupId(string groupId, ITblChatRepository chatRepository);
        void InsertChat(object obj, ITblChatRepository chatRepository);
        TblChat CreateChatObject(object obj);
    }
}
