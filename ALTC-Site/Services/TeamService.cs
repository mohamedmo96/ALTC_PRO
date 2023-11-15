using ALTC_Website.Models;
using ALTC_WebSite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ALTC_Site.Services
{
    public class TeamService : ITeamService
    {
        private readonly IMongoCollection<Team> teamCollection;

        public TeamService(
            IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            teamCollection = mongoDatabase.GetCollection<Team>(
                AltcDatabaseSettings.Value.TeamCollection);
        }
        public void Create(Team teamMember)
        {
            teamCollection.InsertOne(teamMember);
        }

        public void DeleteById(string id)
        {
            teamCollection.DeleteOne(t => t.Id == id);
        }

        public List<Team> GetAll()
        {
            return teamCollection.Find(_=>true).ToList();
        }
        public List<Team> GetAllByLang(string lang)
        {
            return teamCollection.Find(t => t.Language == lang).ToList();
        }

        public Team GetById(string id)
        {
            return teamCollection.Find(t => t.Id == id).FirstOrDefault();
        }

        public void Update(string id, Team teamMember) =>
                  teamCollection.ReplaceOneAsync(x => x.Id == id, teamMember);
    }
}