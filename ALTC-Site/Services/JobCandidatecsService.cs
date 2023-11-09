using ALTC_WebSite.Models;
using ALTC_Website.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.IO;

namespace ALTC_Website.Services
{
    public class JobCandidatecsService : IJobcandidateService
    {
        private readonly IMongoCollection<JobCandidate> jobCandidateCollection;

        public JobCandidatecsService(IOptions<AltcDatabaseSettings> AltcDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AltcDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AltcDatabaseSettings.Value.DatabaseName);

            jobCandidateCollection = mongoDatabase.GetCollection<JobCandidate>(
                AltcDatabaseSettings.Value.JobCandidateCollection3);
        }

        public void Create(JobCandidate jobCandidate)
        {
                        
            jobCandidateCollection.InsertOne(jobCandidate);
        }

        public List<JobCandidate> GetAll()
        {
            return jobCandidateCollection.Find<JobCandidate>(x => true).ToList();
        }
    }
}
