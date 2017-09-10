using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.API.Models.Settings;
using Microsoft.Extensions.Options;
using EH = Enterprise.API.Helpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
#pragma warning disable CS0618 // Type or member is obsolete
                _server = _client.GetServer();
#pragma warning restore CS0618 // Type or member is obsolete
                _database = _server.GetDatabase(option.Value.Database);
            }
        }
        public MongoCollection<TblProductComments> TblProductComments
        {
            get
            {
                return _database.GetCollection<TblProductComments>(EH.Consts.MongoCollections.Tbl_Product_Comments);
            }
        }

        public EntityEntry Entry { get; set; }
    }
}
