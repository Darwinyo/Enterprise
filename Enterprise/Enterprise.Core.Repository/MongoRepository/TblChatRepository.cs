using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.Repository.Abstract;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;

namespace Enterprise.Core.Repository.MongoRepository
{
    public class TblChatRepository : MongoBaseRepository<TblChat>, ITblChatRepository
    {
        public TblChatRepository(IOptions<MongoDBSettings> options) : base(options)
        {
        }
    }
}
