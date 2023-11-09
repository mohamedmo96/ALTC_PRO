using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Amazon.Runtime.Internal;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ALTC_Website.Services
{
    public class TechnicalSupportService : ITechnicalSupportService
    {
        private readonly IMongoCollection<TechnicalSupport> TechnicalSupportCollection;

        public TechnicalSupportService(IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            TechnicalSupportCollection = mongoDatabase.GetCollection<TechnicalSupport>(
                AltcDatabaseSettings.Value.TechnicalCollection);
        }
        public void Create(TechnicalSupport technicalSupport) =>
           TechnicalSupportCollection.InsertOne(technicalSupport);

        public List<TechnicalSupport> GetAll()
        {
            return TechnicalSupportCollection.Find<TechnicalSupport>(ix => true).ToList();


        }
    }
}
