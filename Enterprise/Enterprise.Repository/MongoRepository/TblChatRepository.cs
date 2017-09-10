using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.Abstract;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;

namespace Enterprise.Repository.MongoRepository
{
    public class TblChatRepository : MongoBaseRepository<TblChat>, ITblChatRepository
    {
        public TblChatRepository(IOptions<MongoDBSettings> options) : base(options)
        {
        }
    }
}
