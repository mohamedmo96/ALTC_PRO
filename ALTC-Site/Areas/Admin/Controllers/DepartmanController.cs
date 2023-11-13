using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ALTC_Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmanController : Controller
    {
        private readonly IDepartment department;
        private readonly IWebHostEnvironment hostEnvironment;


        public DepartmanController(IDepartment department, IWebHostEnvironment _webHostEnvironment)
        {
            this.department = department;
            hostEnvironment = _webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeptVM requestVM)
        {

            Department request = new Department()
            {
                Name = requestVM.Name,
                Describtion = requestVM.Describtion,

            };
            if (requestVM.File != null)
            {

                string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string fileName = ALTC_Website.Abstract.File.Upload(uploadPath, requestVM.File);

                request.FileName = fileName;
            }
            department.Create(request);

            return RedirectToAction("index");


        }

    }
}
