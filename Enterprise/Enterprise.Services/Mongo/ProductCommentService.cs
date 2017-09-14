using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Services.Mongo.Abstract;
using Enterprise.API.BusinessLogics.Mongo;
using Microsoft.Extensions.Options;
using Enterprise.API.Models.Settings;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.Mongo
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly ITblProductCommentsRepository _tblProductCommentsRepository;
        private readonly ProductCommentsBusinessLogic _productCommentsBusinessLogic;
        public ProductCommentService(ITblProductCommentsRepository tblProductCommentsRepository, IOptions<MongoDBSettings> options)
        {
            _tblProductCommentsRepository = tblProductCommentsRepository;
            _productCommentsBusinessLogic = new ProductCommentsBusinessLogic(new MongoContext(options));
        }
        public IEnumerable<TblProductComments> GetAllCommentListByProductId(string productId)
        {
            return _productCommentsBusinessLogic.GetAllCommentListByProductId(productId, _tblProductCommentsRepository);
        }
    }
}
