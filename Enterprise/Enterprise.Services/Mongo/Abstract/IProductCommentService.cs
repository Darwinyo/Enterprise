using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.MongoRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Services.Mongo.Abstract
{
    public interface IProductCommentService
    {
        IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId);
    }
}
