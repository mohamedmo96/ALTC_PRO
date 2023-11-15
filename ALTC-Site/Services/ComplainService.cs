using ALTC_Website.Models;
using ALTC_Website.Services;
using ALTC_WebSite.Models;
using ALTC_WebSite.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ALTC_WebSite.Services
{
    public class ComplainService : IComplainService
    {
        private readonly IMongoCollection<Complain> _complainCollection;

        public ComplainService(IOptions<AltcDatabaseSettings> altcDatabaseSettings)
        {
            var mongoClient = new MongoClient(altcDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(altcDatabaseSettings.Value.DatabaseName);
            _complainCollection = mongoDatabase.GetCollection<Complain>(
                altcDatabaseSettings.Value.ComplainCollection);
        }

        public async Task CreateAsync(Complain newComplain) =>
            await _complainCollection.InsertOneAsync(newComplain);

        public void Add(Complain newComplain)
        {
            _complainCollection.InsertOne(newComplain);
        }

        public Complain GetComplaintById(string id)
        {
            return _complainCollection.Find(x => x.id == id).FirstOrDefault();
        }

        public List<Complain> GetAllComplaints()
        {
            return _complainCollection.Find(_ => true).ToList();
        }

        public void Add(Login obj)
        {
            throw new NotImplementedException();
        }
    }
}