
using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Encodings.Web;
using System.Web;

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
            HttpUtility.HtmlEncode(staticDataaa.aboutus);
            StaticCollection.InsertOne(staticDataaa);
        }

        public void Delete(string id)
        {
            var filter = Builders<StaticData>.Filter.Eq("_id", ObjectId.Parse(id));
            StaticCollection.DeleteOne(filter);
        }

        public List<StaticData> GetBylang(string lang)
        {
            return StaticCollection.Find(s => s.lang == lang).ToList();
        }


        public List<StaticData> GetAll()
        {
            return StaticCollection.Find(_ => true).ToList();
        }
        public StaticData GetById(string id)
        {
            return StaticCollection.Find(s => s.id == id).FirstOrDefault();
        }

        public void Update(StaticData staticData)
        {
            StaticCollection.ReplaceOne(s => s.id == staticData.id, staticData);
        }
    }
}
