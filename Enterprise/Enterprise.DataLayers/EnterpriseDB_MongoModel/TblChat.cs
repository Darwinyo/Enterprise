using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.DataLayers.EnterpriseDB_MongoModel
{
    public class TblChat
    {
        public ObjectId Id { get; set; }
        [BsonElement("User_Id")]
        public string UserId { get; set; }
        [BsonElement("Message")]
        public string Message { get; set; }
        [BsonElement("Message_Datetime")]
        public string MessageDatetime { get; set; }
        [BsonElement("Group_Id")]
        public string GroupId { get; set; }
    }
}
