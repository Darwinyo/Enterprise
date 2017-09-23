using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.Mongo.Abstract
{
    public interface IChatBusinessLogic
    {
        IEnumerable<TblChat> GetChatByGroupId(string groupId);
        void InsertChat(object obj);
        TblChat CreateChatObject(object obj);
    }
}
