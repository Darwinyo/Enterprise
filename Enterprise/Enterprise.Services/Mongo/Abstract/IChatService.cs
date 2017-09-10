using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using System.Collections.Generic;

namespace Enterprise.Services.Mongo.Abstract
{
    public interface IChatService
    {
        IEnumerable<TblChat> GetChatByGroupId(string groupId);
        void InsertChat(object obj);
    }
}
