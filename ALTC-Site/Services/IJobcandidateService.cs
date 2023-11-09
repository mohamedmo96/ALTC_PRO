using ALTC_WebSite.Models;
using System.Collections.Generic;

namespace ALTC_Website.Services
{
    public interface IJobcandidateService
    {
        void Create(JobCandidate jobCandidate);
        List<JobCandidate> GetAll();
    }
}
