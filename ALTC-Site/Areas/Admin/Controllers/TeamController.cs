using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_Website.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ALTC_Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IWebHostEnvironment hostEnvironment;
        string uploadPath; 

        public TeamController(ITeamService _teamService,IWebHostEnvironment webHostEnvironment)
        {
            hostEnvironment = webHostEnvironment;
            teamService = _teamService;
            uploadPath=Path.Combine(hostEnvironment.WebRootPath, "Files");
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

               // string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string photoName = ALTC_Website.Abstract.File.Upload(uploadPath, teamMemberVM.Photo);

                teamMember.PhotoName = photoName;

            }
            teamService.Create(teamMember);
            return View();
        }

        public IActionResult DeleteOne(string id) 
        {
            if(id == null)
            {
                return View(nameof(NotFound));
            }
            teamService.DeleteById(id);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var teamMember=teamService.GetById(id);

            if(teamMember == null)
            {
                return View(nameof(NotFound));
            }
            TeamVM teamMemeberVM= new TeamVM()
            {
                Id = teamMember.Id,
                Email=teamMember.Email,
                Phone = teamMember.Phone,
                Name = teamMember.Name,
            };
            teamMemeberVM.PhotoUrl = Path.Combine(uploadPath, teamMember.PhotoName);

            return View(teamMemeberVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id ,TeamVM teamMemberVM)
        {
            if(id==null ||id!=teamMemberVM.Id) { return View(nameof(NotFound)); }
            if (!ModelState.IsValid)
            {
                return View(teamMemberVM);
            }
             Team teamMember=teamService.GetById(id);
            teamMember.Email = teamMemberVM.Email;
            teamMember.Phone = teamMemberVM.Phone;
            teamMember.Name = teamMemberVM.Name;
            if (teamMemberVM.Photo!= null)
            {   
                teamMember.PhotoName = ALTC_Website.Abstract.File.Upload(uploadPath, teamMemberVM.Photo);
            }

            teamService.Update(id,teamMember);
            return RedirectToAction(nameof(Index));


        }

    }
}
