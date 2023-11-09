using ALTC_Site.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Site.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        public TeamController(ITeamService _teamService)
        {
            teamService = _teamService;
        }
        public IActionResult Index()
        {
            var teamMembers = teamService.GetAll();
            return View(teamMembers);
        }
    }
}