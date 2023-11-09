using ALTC_WebSite.Models;

namespace ALTC_Site.Services
{
    public interface ITeamService
    {
        void Create(Team teamMember);
        void Update(string id, Team teamMember);

        Team GetById(string id);
        List<Team> GetAll();

        void DeleteById(string id);

    }
}