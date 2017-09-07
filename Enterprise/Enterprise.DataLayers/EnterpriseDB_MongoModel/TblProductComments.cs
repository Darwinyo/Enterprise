using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.DataLayers.EnterpriseDB_MongoModel
{
    public partial class TblProductComments
    {
        public ObjectId Id { get; set; }
        [BsonElement("Product_Id")]
        public string ProductId { get; set; }
        [BsonElement("User_Id")]
        public string UserId { get; set; }
        [BsonElement("Comment")]
        public string Comment { get; set; }
        [BsonElement("Comment_datetime")]
        public DateTime CommentDatetime { get; set; }
    }
}
