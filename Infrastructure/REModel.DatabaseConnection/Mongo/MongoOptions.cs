using System;
using System.Collections.Generic;
using System.Text;

namespace REModel.DatabaseConnection.Mongo
{
    public class MongoOptions
    {
        public bool Seed { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
