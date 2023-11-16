using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace ALTC_Site.Areas.Admin.Controllers
{
   // [Authorize]

    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IWebHostEnvironment hostEnvironment;
        string uploadPath;
        string lanugagel;

        public TeamController(ITeamService _teamService,IWebHostEnvironment webHostEnvironment)
        {
            hostEnvironment = webHostEnvironment;
            teamService = _teamService;
            uploadPath=Path.Combine(hostEnvironment.WebRootPath, "Files");
          //  lanugagel = "En";
        }

        public IActionResult Index()
        {
            var teamMembers = teamService.GetAll();
            return View(teamMembers);
        }

        public IActionResult Create()
        {
            var language = new List<string> { "En", "Ar" };//Enum.GetNames(typeof(Language)).ToString();
            ViewData["lang"] = language;
           // return PartialView();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamVM teamMemberVM)
        {

            if (!ModelState.IsValid/* || ALTC_Website.Abstract.File.ValidPhotoExtension(teamMemberVM.Photo)*/)
            {
              //  ModelState.AddModelError("Photo", "Invalid extension");
                ViewData["lang"] = new List<string> { "En", "Ar" }; //Enum.GetNames(typeof(Language)).ToString();
               // return PartialView(teamMemberVM);
                return View(teamMemberVM);
            }
            Team teamMember = new Team()
            {
                Name = teamMemberVM.Name,
                Phone = teamMemberVM.Phone,
                Facebook = teamMemberVM.Facebook,
                Linkedin = teamMemberVM.Linkedin,
                Twitter = teamMemberVM.Twitter,
                Position = teamMemberVM.Position,
                Language = teamMemberVM.Language,
            };
            if (teamMemberVM.Photo != null)
            {

               // string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string photoName = ALTC_Website.Abstract.File.Upload(uploadPath, teamMemberVM.Photo);

                teamMember.PhotoName = photoName;

            }
            teamService.Create(teamMember);
            return RedirectToAction(nameof(Index));
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
                Twitter=teamMember.Twitter,
                Facebook=teamMember.Facebook,
                Linkedin=teamMember.Linkedin,
                Position = teamMember.Position,
                Phone = teamMember.Phone,
                Name = teamMember.Name,
                Language = teamMember.Language,
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
            teamMember.Position=teamMemberVM.Position;
            teamMember.Twitter=teamMemberVM.Twitter;
            teamMember.Facebook=teamMemberVM.Facebook;
            teamMember.Linkedin=teamMemberVM.Linkedin;
            teamMember.Phone = teamMemberVM.Phone;
            teamMember.Name = teamMemberVM.Name;
            teamMember.Language=teamMemberVM.Language;
            if (teamMemberVM.Photo!= null)
            {   
                teamMember.PhotoName = ALTC_Website.Abstract.File.Upload(uploadPath, teamMemberVM.Photo);
            }

            teamService.Update(id,teamMember);
            return RedirectToAction(nameof(Index));


        }


        public IActionResult ValidTeamName(string name,string Language)
        {
            string arabicPattern = @"^[\u0600-\u06FF]+(\s[\u0600-\u06FF]+)+$";
            string englishPattern = @"^[A-Za-z]+( [A-Za-z]+)+$";
            if (Language == "En" && Regex.IsMatch(name,englishPattern))
            {
                return Json(true);
            }
            if(Language == "Ar" && Regex.IsMatch(name,arabicPattern)) { return Json(true); }

            return Json(false);


        }

    }
}
