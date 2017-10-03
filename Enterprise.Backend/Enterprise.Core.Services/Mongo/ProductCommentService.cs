using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.Services.Mongo.Abstract;
using Enterprise.Core.BusinessLogics.Mongo.Abstract;

namespace Enterprise.Core.Services.Mongo
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IProductCommentsBusinessLogic _productCommentsBusinessLogic;
        public ProductCommentService(IProductCommentsBusinessLogic productCommentsBusinessLogic)
        {
            _productCommentsBusinessLogic = productCommentsBusinessLogic;
        }
        public IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId)
        {
            return _productCommentsBusinessLogic.GetAllCommentListByProductId(productId);
        }
    }
}
