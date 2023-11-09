﻿
using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ALTC_Website.Services
{
    public class StaticDataService : IStaticData
    {
        private readonly IMongoCollection<StaticData> StaticCollection;

        public StaticDataService(IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            StaticCollection = mongoDatabase.GetCollection<StaticData>(
                AltcDatabaseSettings.Value.StaticCollection3);
        }
        public void Create(StaticData staticDataaa )
        {
            StaticCollection.InsertOne(staticDataaa);
        }

        public void Delete(string id)
        {
            var filter = Builders<StaticData>.Filter.Eq("_id", ObjectId.Parse(id));
            StaticCollection.DeleteOne(filter);
        }

       

        public List<StaticData> GetAll()
        {
            return StaticCollection.Find(_ => true).ToList();
        }

    }
}
