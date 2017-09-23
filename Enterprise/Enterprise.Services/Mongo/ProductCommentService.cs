using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Services.Mongo.Abstract;
using Enterprise.API.BusinessLogics.Mongo.Abstract;

namespace Enterprise.Services.Mongo
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
