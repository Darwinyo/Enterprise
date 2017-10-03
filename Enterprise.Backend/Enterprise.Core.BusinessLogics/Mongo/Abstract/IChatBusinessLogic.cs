using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Core.BusinessLogics.Mongo.Abstract
{
    public interface IChatBusinessLogic
    {
        IEnumerable<TblChat> GetChatByGroupId(string groupId);
        void InsertChat(object obj);
        TblChat CreateChatObject(object obj);
    }
}
