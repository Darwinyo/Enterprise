using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;
using EH = Enterprise.API.Helpers;

namespace Enterprise.DataLayers.EnterpriseDB_MongoModel
{
    public partial class MongoContext
    {
        private readonly MongoClient _client;
        private readonly MongoDatabase _database;
        private readonly MongoServer _server;
        public MongoContext(IOptions<MongoDBSettings> option)
        {
            _client = new MongoClient(option.Value.ConnectionString);
            if (_client != null)
            {
                _server = _client.GetServer();
                _database = _server.GetDatabase(option.Value.Database);
            }
        }
        public MongoCollection<TblProductComments> TblProductComments
        {
            get
            {
                return _database.GetCollection<TblProductComments>(Enum.GetName(typeof(EH.Enums.MongoDBCollectionEnum), EH.Enums.MongoDBCollectionEnum.Tbl_Product_Comments));
            }
        }
    }
}
