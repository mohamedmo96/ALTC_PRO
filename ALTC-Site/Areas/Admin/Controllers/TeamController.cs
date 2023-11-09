using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_Website.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ALTC_Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IWebHostEnvironment hostEnvironment;
        public TeamController(ITeamService _teamService,IWebHostEnvironment webHostEnvironment)
        {
            hostEnvironment = webHostEnvironment;
            teamService = _teamService;
        }
        public IActionResult Index()
        {
            var teamMembers = teamService.GetAll();
            return View(teamMembers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamVM teamMemberVM)
        {
            if (!ModelState.IsValid)
            {
                return View(teamMemberVM);
            }
            Team teamMember = new Team()
            {
                Name = teamMemberVM.Name,
                Phone = teamMemberVM.Phone,
                Email = teamMemberVM.Email,
            };
            if (teamMemberVM.Photo != null)
            {

                string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string photoName = ALTC_Website.Abstract.File.Upload(uploadPath, teamMemberVM.Photo);

                teamMember.PhotoName = photoName;

            }
            teamService.Create(teamMember);
            return View();


        }

    }
}
