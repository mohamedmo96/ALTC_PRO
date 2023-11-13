using ALTC_Site.Models;
using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ALTC_Site.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMongoCollection<Account> accountCollection;

        public AccountService(IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            accountCollection = mongoDatabase.GetCollection<Account>(
                AltcDatabaseSettings.Value.AccountCollection);
        }
        public void Add(Account account)
        {
            accountCollection.InsertOne(account);
        }

        public void Delete(string accountId)
        {
            accountCollection.DeleteOne(a=>a.Id==accountId);
        }

        public List<Account> GetAll()
        {
           return accountCollection.Find(_=>true).ToList(); 
        }

        public Account Get(string email, string password)
        {
           return accountCollection.Find(a=>a.Email== email && a.Password == password).FirstOrDefault();
        }
        public Account GetById(string id)
        {
           return accountCollection.Find(a=>a.Id== id).FirstOrDefault();
        }

        public bool IsAuthenticated(string email, string password)
        {
            Account user = accountCollection.Find(a=>a.Email== email && a.Password == password).FirstOrDefault();
            if(user != null)
            {
                return true;
            }
            return false;
            
        }

  
    }
}
