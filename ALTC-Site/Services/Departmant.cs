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

        public void Create(Department department)
        {

            DeptCollection.InsertOne(department);
        }

        public List<Department> GetAll()
        {
            return DeptCollection.Find<Department>(x => true).ToList();
        }
        public void Delete(string id)
        {
            var filter = Builders<Department>.Filter.Eq("_id", ObjectId.Parse(id));
            DeptCollection.DeleteOne(filter);
        }
    }
}
