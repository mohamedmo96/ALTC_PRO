using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_Website.Services;
using ALTC_Website.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ALTC_Website.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly IDepartment requestService;
        private readonly IWebHostEnvironment hostEnvironment;

        public DepartmanController(IDepartment _requestService , IWebHostEnvironment _webHostEnvironment)
        {
            requestService = _requestService;
            hostEnvironment = _webHostEnvironment;

        }
        public IActionResult GetAll()
        {
            var model = requestService.GetAll();
            return View(model);
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
                string fileName = Abstract.File.Upload(uploadPath, requestVM.File);

                request.FileName = fileName;
            }
            requestService.Create(request);

            return RedirectToAction("index");


        }
        public IActionResult Delete(string id)
        {
            requestService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
  
   
}
