using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.Repository.MongoRepository
{
    
    public class TblProductCommentsRepository:MongoBaseRepository<TblProductComments>,ITblProductCommentsRepository
    {
        public TblProductCommentsRepository(IOptions<MongoDBSettings> options) : base(options)
        {
        }
    }
}
