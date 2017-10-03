using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Core.BusinessLogics.Mongo.Abstract
{
    public interface IProductCommentsBusinessLogic
    {
        IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId);
    }
}
