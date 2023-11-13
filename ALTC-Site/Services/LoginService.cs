using ALTC_Website.Models;
using ALTC_Website.Services;
using ALTC_WebSite.Models;
using ALTC_WebSite.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ALTC_WebSite.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMongoCollection<Login> _loginCollection;

        public LoginService(IOptions<AltcDatabaseSettings> altcDatabaseSettings)
        {
            var mongoClient = new MongoClient(altcDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(altcDatabaseSettings.Value.DatabaseName);
            _loginCollection = mongoDatabase.GetCollection<Login>(
                altcDatabaseSettings.Value.LoginCollection);
        }

        public async Task CreateAsync(Login newLogin) =>
            await _loginCollection.InsertOneAsync(newLogin);

        public void Add(Login newLogin)
        {
            _loginCollection.InsertOne(newLogin);
        }

       

        //public Complain GetComplaintById(string id)
        //{
        //    return _loginCollection.Find(x => x.id == id).FirstOrDefault();
        //}

        //public List<Complain> GetAllComplaints()
        //{
        //    return _loginCollection.Find(_ => true).ToList();
        //}

    }
}