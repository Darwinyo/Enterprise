using System.Collections.Generic;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.API.BusinessLogics.Mongo.Abstract;
using Enterprise.Repository.Abstract;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;

namespace Enterprise.API.BusinessLogics.Mongo
{
    public class ProductCommentsBusinessLogic:IProductCommentsBusinessLogic
    {
        private readonly MongoContext _context;
        private readonly ITblProductCommentsRepository _productCommentsRepository;
        public ProductCommentsBusinessLogic(ITblProductCommentsRepository productCommentsRepository, IOptions<MongoDBSettings> options)
        {
            _productCommentsRepository = productCommentsRepository;
            _context = new MongoContext(options);
        }
        public IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId)
        {
            IMongoQuery mongoQuery = Query<TblProductComments>.EQ(x => x.ProductId, productId);
            return _productCommentsRepository.FindBy(_context.TblProductComments, mongoQuery);
        }
    }
}
