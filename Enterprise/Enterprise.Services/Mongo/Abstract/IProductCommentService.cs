using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.Repository.MongoRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Core.Services.Mongo.Abstract
{
    public interface IProductCommentService
    {
        IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId);
    }
}
