using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.Mongo.Abstract
{
    public interface IProductCommentsBusinessLogic
    {
        IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId, ITblProductCommentsRepository context);
    }
}
