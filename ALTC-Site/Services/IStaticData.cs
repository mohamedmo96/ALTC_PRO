using ALTC_WebSite.Models;

namespace ALTC_Website.Services
{
    public interface IStaticData
    {
        void Create(StaticData  staticData);
        public List<StaticData> GetAll();
        void Delete(string id);

    }
}
