using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.Models.Settings
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
