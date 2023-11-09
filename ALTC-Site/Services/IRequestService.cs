using ALTC_WebSite.Models;

namespace ALTC_Website.Services
{
    public interface IRequestService
    {
        public void Create(Request request);
        public List<Request> GetAll();

        public Request GetById(string id);
    }
}
