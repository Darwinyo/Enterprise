using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Repository.MongoRepository;
using Enterprise.API.BusinessLogics.Mongo.Abstract;

namespace Enterprise.API.BusinessLogics.Mongo
{
    public class ProductCommentsBusinessLogic:IProductCommentsBusinessLogic
    {
        private readonly MongoContext _context;
        public ProductCommentsBusinessLogic(MongoContext context)
        {
            _context = context;
        }
        public IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId, TblProductCommentsRepository context)
        {
            IMongoQuery mongoQuery = Query<TblProductComments>.EQ(x => x.ProductId, productId);
            return context.FindBy(_context.TblProductComments, mongoQuery);
        }
    }
}
