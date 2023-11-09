using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace ALTC_Website.Services
{
    public class RequestService : IRequestService
    {
        //private readonly 
        private readonly IMongoCollection<Request> requestCollection;

        public RequestService(
            IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            requestCollection = mongoDatabase.GetCollection<Request>(
                AltcDatabaseSettings.Value.RequestCollection);
        }
        public void Create(Request request) =>
           requestCollection.InsertOne(request);

        public List<Request> GetAll() =>
            requestCollection.Find(_ => true).ToList();

        public Request GetById(string id) =>
            requestCollection.Find(r => r.id == id).FirstOrDefault();
    }
}
