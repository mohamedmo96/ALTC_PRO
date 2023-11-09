using ALTC_WebSite.Models;
using Amazon.Runtime.Internal;

namespace ALTC_Website.Services
{
    public interface ITechnicalSupportService
    {
         void Create(TechnicalSupport technicalSupport);
        public List<TechnicalSupport> GetAll();

    }
}
