

using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ALTC_WebSite.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IMongoCollection<Service> _ServiceCollection;

        public ServiceService(
             IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            _ServiceCollection = mongoDatabase.GetCollection<Service>(
                AltcDatabaseSettings.Value.ServiceCollection);
        }

        public void Add(Service newService)
        {
            _ServiceCollection.InsertOne(newService);
        }

        public List<Service> GetAllServices()
        {
            return _ServiceCollection.Find(_ => true).ToList();
        }

        public Service GetServiceById(string id)
        {
            return _ServiceCollection.Find(service => service.id == id).FirstOrDefault();
        }
        public List<Service> GetBylang(string lang)
        {
            return _ServiceCollection.Find(s => s.lang == lang).ToList();
        }
        public void UpdateService(string id, Service updatedService)
        {
            var filter = Builders<Service>.Filter.Eq("id", id);
            var update = Builders<Service>.Update
                .Set("Name", updatedService.Name)
                .Set("FileName", updatedService.FileName)
                .Set("lang", updatedService.lang)
                .Set("Details", updatedService.Details);
            _ServiceCollection.UpdateOne(filter, update);
        }

        public void DeleteService(string id)
        {
            _ServiceCollection.DeleteOne(service => service.id == id);
        }

      
    }
}
