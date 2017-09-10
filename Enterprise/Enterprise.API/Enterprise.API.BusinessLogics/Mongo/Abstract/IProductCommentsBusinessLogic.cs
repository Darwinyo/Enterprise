using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.MongoRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.BusinessLogics.Mongo.Abstract
{
    public interface IProductCommentsBusinessLogic
    {
        IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId, TblProductCommentsRepository context);
    }
}
