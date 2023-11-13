using ALTC_WebSite.Models;
using ALTC_Website.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.IO;
using ALTC_Site.Services;
using MongoDB.Bson;

namespace ALTC_Website.Services
{
    public class Departmant : IDepartment
    {
        private readonly IMongoCollection<Department> DeptCollection;

        public Departmant(IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            DeptCollection = mongoDatabase.GetCollection<Department>(
                AltcDatabaseSettings.Value.Department);
        }

    
    }
}
