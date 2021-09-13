using MongoDB.Driver;
using StudentPortal.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.Infrastructure.Data
{
   public class MongoContext
    {
        MongoClient client;
        IMongoDatabase database;

        public MongoContext()
        {
            client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("StudentPortal");
        }

        public IMongoCollection<Login>Logins=>database.GetCollection<Login>("Login");
    }
}
